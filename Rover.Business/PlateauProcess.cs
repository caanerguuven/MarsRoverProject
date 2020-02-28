using Rover.Business.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business
{
    public class PlateauProcess : Process
    {
        private readonly string ConsoleSentences = "Please Type Plateau Row And Column Number : ";
        public override void Run(ProcessModel processModel)
        {
            bool isValidate;
            do
            {
                Console.Write(ConsoleSentences);
                EnterValue = Console.ReadLine();

                isValidate = Validate();
                if (!isValidate)
                {
                    break;
                }

                processModel.PlateauModel = new PlateauModel()
                {
                    Apsis = Convert.ToInt32(EnterValue.Split(" ")[0]),
                    Ordinate = Convert.ToInt32(EnterValue.Split(" ")[1]),
                };

                if (NextProcess != null)
                {
                    NextProcess.Run(processModel);
                }

            } while (isValidate);
        }

        public override bool Validate()
        {
            try
            {
                EnterValue
                    .IsAllInfosEntered(2)
                    .IsAllInfosNumber();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Values not valid ! Exception Message : {ex.Message} ");
                return false;
            }

            return true;
        }
    }
}
