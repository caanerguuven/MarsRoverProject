using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rover.Helper.Extension
{
    public static class ValidateExtension
    {
        public static string IsAllInfosEntered(this string value,int expectedNumber)
        {
            int totalNumber = value.Split(" ").Length;
            if (totalNumber!= expectedNumber)
            {
                throw new Exception($"not equal expected number ({expectedNumber})");
            }
            return value;
        }

        public static string IsAllInfosNumber(this string value)
        {
            if (!value.Replace(" ",string.Empty).Trim().All(char.IsDigit))
            {
                throw new Exception("not numeric value detected !");
            }
            return value;
        }

        public static string IsInRange(this string value,int maxNumber)
        {
            int intValue;
            int.TryParse(value, out intValue);

            if (intValue<0 || intValue>maxNumber)
            {
                throw new Exception("overflow numeric value detected !");
            }
            return value;
        }

        public static string HasContainsDirectionLetters(this string value)
        {
            var collection = new List<char>() { 'L', 'R', 'M' };
            HasContainsLetters(value, collection);
            return value;
        }

        public static string HasContainsOrientationLetters(this string value)
        {
            var collection = new List<char>() { 'n', 's', 'w', 'e' };
            HasContainsLettersWithLengthControl(value, collection);
            return value;
        }

        public static string HasContainsApproveLetters(this string value)
        {
            var collection = new List<char>() { 'y', 'n' };
            HasContainsLettersWithLengthControl(value, collection);
            return value;
        }

        public static string HasContainsLettersWithLengthControl(string value, List<char> items)
        {
            string valueUpdated = value.Trim().ToLower();
            if (valueUpdated.Length > 1)
            {
                throw new Exception("wrong value detected !");
            }
            HasContainsLetters(valueUpdated, items);

            return value;
        }

        public static string HasContainsLetters(string value, List<char> items)
        {
            bool isNotContain = !items.Any(item => value.Contains((char)item));
            if (isNotContain)
            {
                throw new Exception("invalid value detected !");
            }

            return value;
        }
    }
}
