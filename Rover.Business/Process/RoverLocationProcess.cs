using Rover.Business.Process.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using Rover.Model.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business.Process
{
    public class RoverLocationProcess : IProcess
    {
        private readonly string ConsoleSentences = "Please Type Apsis And Ordinate Values of {0}.Rover : ";
        private ProcessModel _processModel { get; set; }
        private string _apsisValue, _ordinateValue, _orientationValue;
        public override void Run(ProcessModel processModel)
        {
            bool isValidate = false;
            _processModel = processModel;

            while (!isValidate)
            {
                Console.Write(string.Format(ConsoleSentences, processModel.RoverIndex));
                EnterValue = Console.ReadLine().TrimStart().TrimEnd();

                isValidate = Validate();
                if (isValidate)
                {
                    RoverLocationModel location = new RoverLocationModel()
                    {
                        Apsis = Convert.ToInt32(_apsisValue),
                        Ordinate = Convert.ToInt32(_ordinateValue),
                        Orientation = _orientationValue,
                        MaxApsisLimit = processModel.PlateauModel.Apsis,
                        MaxOrdinateLimit = processModel.PlateauModel.Ordinate
                    };

                    processModel.CurrentRover = new RoverModel();
                    processModel.CurrentRover.Location = location;

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
                EnterValue.IsAllInfosEntered(3);

                _apsisValue = EnterValue.Split(" ")[0];
                _apsisValue.IsInRange(_processModel.PlateauModel.Apsis);

                _ordinateValue = EnterValue.Split(" ")[1];
                _ordinateValue.IsInRange(_processModel.PlateauModel.Ordinate);

                _orientationValue = EnterValue.Split(" ")[2];
                _orientationValue.HasContainsOrientationLetters();

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
