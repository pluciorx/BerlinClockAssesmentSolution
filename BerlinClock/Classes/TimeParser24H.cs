using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class TimeParser24H : ITimeParser
    {


        public TimeSpan ParseStringToTimeSpan(string givenTime24H)
        {
            TimeSpan result;
            var format = "hh\\:mm\\:ss";
            if (givenTime24H.Substring(0,2) == "24")
            {
                return new TimeSpan(1, 0, 0, 0);
            } 
                
            if (!TimeSpan.TryParseExact(givenTime24H, format, null, out result))
            {
                throw new FormatException("Given time is incorrect format");
            }
            return result;

        }
    }
}
