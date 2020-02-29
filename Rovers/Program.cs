using Rover.Business.Process;
using Rover.Business.Trigger;
using Rover.Model;
using Rover.Model.Process;
using System;
using System.Collections.Generic;

namespace Rovers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Welcome World Of The Rovers !");
            Console.WriteLine("-----------------------------");

            ProcessModel _model = CreateProcessModel();

            Console.WriteLine("*****************************");
            Console.WriteLine("Let's start. ");

            RoverDriver _driver = new RoverDriver(_model);
            List<RoverLocationModel> roverLocations = _driver.Start();

            roverLocations.ForEach(x =>
            {
                Console.WriteLine("**********************************");
                Console.WriteLine($"X :{x.Apsis} Y:{x.Ordinate} Orientation : {x.Orientation}");
                Console.WriteLine("----------------------------------");
            });
            

        }

        public static ProcessModel CreateProcessModel()
        {
            ProcessModel model = new ProcessModel();
            InitializeProcess initializeProcess = new InitializeProcess();
            RoverLocationProcess roverLocationProcess = new RoverLocationProcess();
            RoverMovementProcess roverMovementProcess = new RoverMovementProcess();
            RoverAddNewProcess addNewProcess = new RoverAddNewProcess();

            initializeProcess.SetNextProcess(roverLocationProcess);
            roverLocationProcess.SetNextProcess(roverMovementProcess);
            roverMovementProcess.SetNextProcess(addNewProcess);

            initializeProcess.Run(model);
            return model;
        }


    }
}
