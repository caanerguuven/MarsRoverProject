using Rover.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Model
{
    public class RoverMovementModel: IMove
    {
        public string MovementLetters { get; set; }

        public void Move(string direction)
        {
            throw new NotImplementedException();
        }
    }
}
