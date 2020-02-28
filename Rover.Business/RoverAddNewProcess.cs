using Rover.Business.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business
{
    public class RoverAddNewProcess : Process
    {
        private readonly string ConsoleSentences = "Could you add new rover ? (y/n) ";
        public override void Run(ProcessModel processModel)
        {
            bool isValidate;
            do
            {
                Console.Write(ConsoleSentences);
                EnterValue = Console.ReadLine().ToUpper();

                isValidate = Validate();
                if (!isValidate)
                {
                    break;
                }

                processModel.RoverModels.Enqueue(processModel.CurrentRover);
                processModel.CurrentRover = null;

                if (NextProcess != null)
                {
                    if (EnterValue == "Y")
                    {
                        processModel.RoverIndex += 1;
                        NextProcess.SetNextProcess(new RoverLocationProcess());
                        NextProcess.Run(processModel);
                    }
                }

            } while (isValidate);
        }

        public override bool Validate()
        {
            try
            {
                EnterValue.IsAllInfosEntered(1).HasContainsApproveLetters();
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
