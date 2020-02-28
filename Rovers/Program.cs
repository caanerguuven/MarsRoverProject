using Rover.Business;
using Rover.Model;
using System;
using System.Collections.Generic;

namespace Rovers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Start();

        }

        static void Start()
        {

            PlateauProcess plateauProcess = new PlateauProcess();
            RoverLocationProcess roverLocationProcess = new RoverLocationProcess();
            RoverMovementProcess roverMovementProcess = new RoverMovementProcess();
            RoverAddNewProcess addNewProcess = new RoverAddNewProcess();

            plateauProcess.SetNextProcess(roverLocationProcess);
            roverLocationProcess.SetNextProcess(roverMovementProcess);
            roverMovementProcess.SetNextProcess(addNewProcess);

            plateauProcess.Run(new ProcessModel());
        }
    }
}
