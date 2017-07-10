using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClockBuilder : IClockBuilder
    {


        String IClockBuilder.GetClockStringRepresentationFromTimeSpan(TimeSpan givenTime)
        {
          
            
            var berlinStringBuilder = new StringBuilder() ;
            //Lets get the Yelow lamp on top first
            if (givenTime.Seconds % 2 == 0)
            {
                berlinStringBuilder.Append("Y");
            }
            else berlinStringBuilder.Append("O");

            berlinStringBuilder.Append(Environment.NewLine);

            //lets get the top two rows 
            //first second row number 
            var thirdLine = (int)givenTime.TotalHours % 5;
            var secondLine = ((int)givenTime.TotalHours - thirdLine) / 5;

            berlinStringBuilder.Append(secondLine.ConvertToBerlinHourDigit());
            berlinStringBuilder.Append(Environment.NewLine);
            berlinStringBuilder.Append(thirdLine.ConvertToBerlinHourDigit());
            berlinStringBuilder.Append(Environment.NewLine);

            // now lets get the minutes

            var fifth = givenTime.Minutes % 5;
            var fourth = (givenTime.Minutes - fifth) / 5;

            var quarts = (givenTime.Minutes - fifth) / 15;


            var DecMinutes = "OOOOOOOOOOO";
            DecMinutes = DecMinutes.Substring(0, fourth).Replace('O', 'Y').PadRight(11, 'O'); //light all
            var fourthLine = lightQuarts(DecMinutes, quarts);
            
            berlinStringBuilder.Append(fourthLine);
            berlinStringBuilder.Append(Environment.NewLine);

            berlinStringBuilder.Append(fifth.ConvertToBerlinHourDigit().Replace('R', 'Y'));
            string result = berlinStringBuilder.ToString();
            berlinStringBuilder = null;

            return result;

        }

        private string lightQuarts(string decimalMinutes, int quarts)
        {

            return quarts > 0 ? lightQuarts(decimalMinutes.ReplaceAt((3 * quarts)-1, 1, "R"), quarts - 1) : decimalMinutes;

        }

    }
}
