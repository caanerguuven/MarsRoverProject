using Rover.Business.Move.Abstract;
using Rover.Business.Process;
using Rover.Helper.Enum;
using Rover.Helper.Extension;
using Rover.Model;
using Rover.Model.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business.Trigger
{
    public class RoverDriver
    {
        private ProcessModel _model { get; set; }
        private Dictionary<string, IMove> _movers;
        public RoverDriver(ProcessModel processModel)
        {
            _model = processModel;
            LoadMovers();
        }

        private void LoadMovers()
        {
            _movers = new Dictionary<string, IMove>();
            foreach (OrientationEnum orientation in Enum.GetValues(typeof(OrientationEnum)))
            {
                var mover = Activator.CreateInstance(Type.GetType($"Rover.Business.Move.{ orientation.GetDescription()}Move")) as IMove;
                _movers.Add(orientation.ToString(), mover);
            }
        }

        public List<RoverLocationModel> Start()
        {
            List<RoverLocationModel> roverLocations = new List<RoverLocationModel>();
            foreach (var rover in _model.RoverModels)
            {
                var movementMaps = rover.Movement.Maps;

                foreach (var movementMap in movementMaps)
                {
                    string orientationName = rover.Location.Orientation;
                    IMove currentMover = _movers[orientationName];

                    currentMover.Direction = movementMap.Direction;
                    currentMover.Location = rover.Location;

                    if (!string.IsNullOrEmpty(movementMap.Direction))
                    {
                        currentMover.DetermineOrientation();
                    }

                    if (movementMap.IsMove)
                    {
                        currentMover.Move();
                    }
                }

                roverLocations.Add(new RoverLocationModel()
                {
                    Apsis = rover.Location.Apsis,
                    Ordinate = rover.Location.Ordinate,
                    Orientation = rover.Location.Orientation
                });
            }
            return roverLocations;
        }
    }
}
