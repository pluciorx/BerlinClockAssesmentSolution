using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BerlinClock.Classes;


namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            ITimeParser parser = new TimeParser24H();
            IClockBuilder builder = new BerlinClockBuilder();

            var time = parser.ParseStringToTimeSpan(aTime);

            var result = builder.GetClockStringRepresentationFromTimeSpan(time);


            return result;

        }
    }
}
