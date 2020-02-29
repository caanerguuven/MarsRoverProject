using Rover.Business.Move.Abstract;
using Rover.Helper.Enum;
using Rover.Helper.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Business.Move
{
    public class SouthMove : IMove
    {
        public override void DetermineOrientation()
        {
            string orientation = string.Empty;

            if (Direction == DirectionEnum.Left.GetDescription())
            {
                orientation = OrientationEnum.E.ToString();
            }
            else if (Direction == DirectionEnum.Right.GetDescription())
            {
                orientation = OrientationEnum.W.ToString();
            }

            Location.Orientation = orientation;
        }

        public override void Move()
        {
            int ordinate = Location.Ordinate;
            int apsis = Location.Apsis;

            if (Direction == DirectionEnum.Left.GetDescription())
            {
                apsis = apsis + 1;
            }
            else if (Direction == DirectionEnum.Right.GetDescription())
            {
                apsis = apsis - 1;
            }
            else if (string.IsNullOrEmpty(Direction))
            {
                ordinate = ordinate - 1;
            }

            if (IsInPlateauRange(apsis, ordinate))
            {
                Location.Ordinate = ordinate;
                Location.Apsis = apsis;
            }
        }
    }
}
