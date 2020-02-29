using NUnit.Framework;
using Rover.Business.Trigger;
using Rover.Model;
using Rover.Model.Process;
using System.Collections.Generic;

namespace Rover.Test
{
    public class RoverDriverTest
    {
        private ProcessModel _model;
        [SetUp]
        public void Setup()
        {
            PlateauModel _plateauModel = new Model.PlateauModel()
            {
                Apsis = 5,
                Ordinate = 5
            };

            _model = new ProcessModel()
            {
                PlateauModel = _plateauModel,
                RoverModels = new Queue<RoverModel>()
            };

            _model.RoverModels.Enqueue(
                    new RoverModel()
                    {
                        Location = new RoverLocationModel()
                        {
                            Apsis = 1,
                            Ordinate = 2,
                            Orientation = "N",
                            MaxApsisLimit = _plateauModel.Apsis,
                            MaxOrdinateLimit = _plateauModel.Ordinate
                        },
                        Movement = new RoverMovementModel()
                        {
                            MovementLetters = "LMLMLMLMM"
                        }
                    });

            _model.RoverModels.Enqueue(
                    new RoverModel()
                    {
                        Location = new RoverLocationModel()
                        {
                            Apsis = 3,
                            Ordinate = 3,
                            Orientation = "E",
                            MaxApsisLimit = _plateauModel.Apsis,
                            MaxOrdinateLimit = _plateauModel.Ordinate
                        },
                        Movement = new RoverMovementModel()
                        {
                            MovementLetters = "MMRMMRMRRM"
                        }
                    });
        }

        [Test]
        public void RoverDriverTestFor12N()
        {

            RoverDriver _driver = new RoverDriver(_model);
            List<RoverLocationModel> roverLocations = _driver.Start();
            var result = roverLocations[0];
            string resultString = $"{ result.Apsis}{ result.Ordinate}{ result.Orientation}";
            string successString = "13N";

            Assert.AreEqual(successString, resultString);
        }

        [Test]
        public void RoverDriverTestFor33E()
        {

            RoverDriver _driver = new RoverDriver(_model);
            List<RoverLocationModel> roverLocations = _driver.Start();
            var result = roverLocations[1];
            string resultString = $"{ result.Apsis}{ result.Ordinate}{ result.Orientation}";
            string successString = "51E";

            Assert.AreEqual(successString, resultString);
        }
    }
}