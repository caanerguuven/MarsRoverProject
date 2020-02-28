using Rover.Business.Abstract;
using Rover.Helper.Extension;
using Rover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business
{
    public class RoverLocationProcess : Process
    {
        private readonly string ConsoleSentences = "Please Type Apsis And Ordinate Values of Rover : ";
        private ProcessModel _processModel { get; set; }
        private string _apsisValue, _ordinateValue, _orientationValue;
        public override void Run(ProcessModel processModel)
        {
            bool isValidate;
            _processModel = processModel;
            do
            {
                Console.Write(ConsoleSentences);
                EnterValue = Console.ReadLine();

                isValidate = Validate();
                if (!isValidate)
                {
                    Console.WriteLine("An Error Occured !");
                    break;
                }

                RoverLocationModel model = new RoverLocationModel()
                {
                    Apsis = Convert.ToInt32(_apsisValue),
                    Ordinate = Convert.ToInt32(_ordinateValue),
                    Orientation = _orientationValue
                };

                processModel.CurrentRover.RoverLocationModel = model;

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
                Console.WriteLine($"Values not valid ! Exception Message : {ex.Message} ");
                return false;
            }

            return true;
        }
    }
}
