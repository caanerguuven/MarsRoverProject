using Rover.Business.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business
{
    public class RoverMovementProcess : Process
    {
        private readonly string ConsoleSentences = "Please Type Rover Movements : ";
        private ProcessModel _processModel { get; set; }
        private string _apsisValue, _ordinateValue, _orientationValue;
        public override void Run(ProcessModel processModel)
        {
            bool isValidate;
            _processModel = processModel;
            do
            {
                Console.Write(ConsoleSentences);
                EnterValue = Console.ReadLine().ToUpper();

                isValidate = Validate();
                if (!isValidate)
                {
                    Console.WriteLine("An Error Occured !");
                    break;
                }

                RoverMovementModel model = new RoverMovementModel()
                {
                    MovementLetters = EnterValue
                };

                processModel.CurrentRover.RoverMovementModel = model;

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
                EnterValue.IsAllInfosEntered(3).HasContainsDirectionLetters();
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
