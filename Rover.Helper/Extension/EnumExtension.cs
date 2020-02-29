using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Rover.Helper.Extension
{
    public static class EnumExtension
    {
       
        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attributes!=null && attributes.Length>0)
            {
                return attributes[0].Description;
            }

            return source.ToString();
        }
}
}

