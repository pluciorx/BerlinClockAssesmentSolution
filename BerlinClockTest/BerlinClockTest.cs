using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;
using System.Globalization;

namespace BerlinClockTest
{
    [TestClass]
    public class BerlinClockTests
    {
        ITimeParser parser;
        IClockBuilder clockBuilder;

        [TestMethod]
        public void TimeParserTest()
        {
            parser = new TimeParser24H();

            string input = "24:00:00";

            TimeSpan expected = new TimeSpan(1, 0, 0, 0);

            Assert.AreEqual(expected, parser.ParseStringToTimeSpan(input));

            input = "23:59:59";
            expected = new TimeSpan(0, 23, 59, 59);

            Assert.AreEqual(expected, parser.ParseStringToTimeSpan(input));

            input = "00:00:00";
            expected = new TimeSpan(0, 0, 0, 0);

            Assert.AreEqual(expected, parser.ParseStringToTimeSpan(input));


            input = "13:17:01";
            expected = new TimeSpan(0, 13, 17, 1);

            Assert.AreEqual(expected, parser.ParseStringToTimeSpan(input));


        }

        [TestMethod]
        public void TimeParserTestRandom()
        {
            parser = new TimeParser24H();
            var date = DateTime.Now;

            string input = date.ToString("HH:mm:ss", CultureInfo.InvariantCulture); ;

            TimeSpan expected = new TimeSpan(0, date.Hour, date.Minute, date.Second);

            Assert.AreEqual(expected, parser.ParseStringToTimeSpan(input));

        }


        [TestMethod]
        public void ClockBuilderTest()
        {
            clockBuilder = new BerlinClockBuilder();

            var input = new TimeSpan(1, 0, 0, 0);

            var expected = "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO";

            var result = clockBuilder.GetClockStringRepresentationFromTimeSpan(input);

            Assert.AreEqual(expected, result);


            input = new TimeSpan(0, 0, 0, 0);

            expected = "Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO";

            result = clockBuilder.GetClockStringRepresentationFromTimeSpan(input);

            Assert.AreEqual(expected, result);


            input = new TimeSpan(0, 14, 18, 1);

            expected = "O\r\nRROO\r\nRRRR\r\nYYROOOOOOOO\r\nYYYO";

            result = clockBuilder.GetClockStringRepresentationFromTimeSpan(input);

            Assert.AreEqual(expected, result);


            input = new TimeSpan(0, 23, 59, 59);

            expected = "O\r\nRRRR\r\nRRRO\r\nYYRYYRYYRYY\r\nYYYY";

            result = clockBuilder.GetClockStringRepresentationFromTimeSpan(input);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void IntToBerlinConverterTest()
        {
            var expected = "OOOO";
            var input = 0;

            Assert.AreEqual(expected, input.ConvertToBerlinHourDigit());

            expected = "ROOO";
            input = 1;

            Assert.AreEqual(expected, input.ConvertToBerlinHourDigit());
            expected = "RROO";
            input = 2;

            Assert.AreEqual(expected, input.ConvertToBerlinHourDigit());

            expected = "RRRO";
            input = 3;

            Assert.AreEqual(expected, input.ConvertToBerlinHourDigit());

            expected = "RRRR";
            input = 4;

            Assert.AreEqual(expected, input.ConvertToBerlinHourDigit());

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An input of negative was inappropriately allowed.")]
        public void IntToBerlinConverterNegativeRangeTest()
        {

            var input = -1;

            input.ConvertToBerlinHourDigit();



        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An put of range input  was inappropriately allowed.")]
        public void IntToBerlinConverterPositiveRangeTest()
        {

            var input = 44;

            input.ConvertToBerlinHourDigit();



        }

        [TestMethod]
        public void ReplaceAtTest()
        {

            var input = "AAAA";

            Assert.AreEqual("ARAA", input.ReplaceAt(1, 1, "R"));
        }

    }
}
