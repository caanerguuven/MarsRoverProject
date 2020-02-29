using Rover.Business.Process.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using Rover.Model.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business.Process
{
    public class RoverMovementProcess : IProcess
    {
        private readonly string ConsoleSentences = "Please Type {0}.Rover Movements : ";
        public override void Run(ProcessModel processModel)
        {
            bool isValidate = false;
            while (!isValidate)
            {
                Console.Write(string.Format(ConsoleSentences, processModel.RoverIndex));
                EnterValue = Console.ReadLine().TrimStart().TrimEnd().ToUpper();

                isValidate = Validate();
                if (isValidate)
                {
                    RoverMovementModel movement = new RoverMovementModel()
                    {
                        MovementLetters = EnterValue,
                    };

                    processModel.CurrentRover.Movement = movement;

                    if (NextProcess != null)
                    {
                        NextProcess.Run(processModel);
                    }
                }

            }
        }

        public override bool Validate()
        {
            try
            {
                EnterValue.IsAllInfosEntered(1).HasContainsDirectionLetters();
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
