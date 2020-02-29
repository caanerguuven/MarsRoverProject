using Rover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business.Move.Abstract
{
    public abstract class IMove
    {
        public RoverLocationModel Location { get; set; }
        public string Direction { get; set; }
        public abstract void DetermineOrientation();
        public abstract void Move();

        public bool IsInPlateauRange(int apsis,int ordinate)
        {
            if (ordinate < 0 || ordinate > Location.MaxOrdinateLimit || apsis < 0 || apsis > Location.MaxApsisLimit)
            {
                Console.WriteLine("Rover tried to go out of plateau. ");
                return false;
            }
            return true;
        }
         
    }
}
