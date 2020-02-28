using Rover.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Model
{
    public class ProcessModel:IProcessModel
    {
        public PlateauModel PlateauModel { get; set; }
        public RoverModel CurrentRover { get; set; }
        public Queue<RoverModel> RoverModels { get; set; }
        public int RoverIndex { get; set; }
    }
}
