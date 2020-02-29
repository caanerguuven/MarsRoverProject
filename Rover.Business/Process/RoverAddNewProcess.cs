using Rover.Business.Process.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using Rover.Model.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business.Process
{
    public class RoverAddNewProcess : IProcess
    {
        private readonly string ConsoleSentences = "Could you add new rover ? (y/n) ";
        public override void Run(ProcessModel processModel)
        {
            bool isValidate = false;
            while (!isValidate)
            {
                Console.Write(ConsoleSentences);
                EnterValue = Console.ReadLine().TrimStart().TrimEnd().ToUpper();

                isValidate = Validate();
                if (isValidate)
                {
                    processModel.RoverModels.Enqueue(processModel.CurrentRover);
                    processModel.CurrentRover = null;

                    if (EnterValue == "Y")
                    {
                        processModel.RoverIndex += 1;

                        RoverLocationProcess roverLocationProcess = new RoverLocationProcess();
                        RoverMovementProcess roverMovementProcess = new RoverMovementProcess();
                        RoverAddNewProcess addNewProcess = new RoverAddNewProcess();

                        SetNextProcess(roverLocationProcess);
                        roverLocationProcess.SetNextProcess(roverMovementProcess);
                        roverMovementProcess.SetNextProcess(addNewProcess);

                        NextProcess.Run(processModel);
                    }
                }
            }
        }

        public override bool Validate()
        {
            try
            {
                EnterValue.IsAllInfosEntered(1).HasContainsApproveLetters();
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
