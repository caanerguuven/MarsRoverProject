using Rover.Model.Process.Abstract;
using System.Collections.Generic;

namespace Rover.Model.Process
{
    public class ProcessModel:IProcessModel
    {
        public PlateauModel PlateauModel { get; set; }
        public RoverModel CurrentRover { get; set; }
        public Queue<RoverModel> RoverModels { get; set; }
        public int RoverIndex { get; set; }
    }
}
