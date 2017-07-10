using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public static class Helpers
    {
        const string BerlinZero = "OOOO";
        const string BerlinOne = "ROOO";
        const string BerlinTwo = "RROO";
        const string BerlinThree = "RRRO";
        const string BerlinFour = "RRRR";

        public static string ConvertToBerlinHourDigit(this int value)
        {
            switch (value)
            {
                case 0: return BerlinZero;
                case 1: return BerlinOne;
                case 2: return BerlinTwo;
                case 3: return BerlinThree;
                case 4: return BerlinFour;
                default:
                    {
                        throw new ArgumentOutOfRangeException("Only value < 5 are allowed");
                    }
            }
                 
        }

        public static string ReplaceAt(this string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index))
                    .Insert(index, replace);
        }
    }
}
