using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rover.Model
{
    public class RoverMovementModel
    {
        public string MovementLetters { get; set; }
        public List<RoverMovementMap> Maps
        {
            get
            {
                List<RoverMovementMap> movementMaps = new List<RoverMovementMap>();
                var directionArray = MovementLetters.Split("M");
                directionArray = directionArray.Take(directionArray.Count() - 1).ToArray();

                for (int i = 0; i < directionArray.Length; i++)
                {
                    string direction = directionArray[i];
                    if (string.IsNullOrEmpty(direction))
                    {
                        movementMaps.Add(new RoverMovementMap()
                        {
                            Direction = string.Empty,
                            IsMove = true
                        });
                        continue;
                    }

                    for (int j = 0; j < direction.Length; j++)
                    {
                        bool isMove = (j == direction.Length - 1);
                        movementMaps.Add(new RoverMovementMap()
                        {
                            Direction = direction[j].ToString(),
                            IsMove = isMove
                        });
                    }
                }
                return movementMaps;
            }
        }

    }
}
