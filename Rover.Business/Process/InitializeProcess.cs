using Rover.Business.Process.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using Rover.Model.Process;
using System;
using System.Collections.Generic;

namespace Rover.Business.Process
{
    public class InitializeProcess : IProcess
    {
        private readonly string ConsoleSentences = "Please Type Plateau Row And Column Number : ";
        public override void Run(ProcessModel processModel)
        {
            bool isValidate;
            do
            {
                Console.Write(ConsoleSentences);
                EnterValue = Console.ReadLine().TrimStart().TrimEnd();

                isValidate = Validate();
                if (isValidate)
                {
                    processModel.PlateauModel = new PlateauModel()
                    {
                        Apsis = Convert.ToInt32(EnterValue.Split(" ")[0]),
                        Ordinate = Convert.ToInt32(EnterValue.Split(" ")[1]),
                    };

                    processModel.RoverModels = new Queue<RoverModel>();
                    processModel.RoverIndex = 1;
                    
                    if (NextProcess != null)
                    {
                        NextProcess.Run(processModel);
                    }
                }
            } while (!isValidate);
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
                Console.WriteLine($"Oops ? --> Values not valid ! Exception Message : {ex.Message} ");
                Console.WriteLine("------------Please Try Again-----------------------");
                return false;
            }

            return true;
        }
    }
}
