using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Rover.Helper.Enum
{
    public enum OrientationEnum
    {
        [Description("East")]
        E=1,
        [Description("North")]
        N =2,
        [Description("South")]
        S =3,
        [Description("West")]
        W =4
    }
}
