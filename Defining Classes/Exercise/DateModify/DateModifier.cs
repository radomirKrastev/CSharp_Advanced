using System;
using System.Collections.Generic;
using System.Text;

namespace DateModify
{
    public class DateModifier
    {
        public double GetDaysDifference(string firstDate, string secondDate)
        {
            var firstDateInfo = firstDate.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var secondDateInfo = secondDate.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var dateOne = new DateTime(int.Parse(firstDateInfo[0]), int.Parse(firstDateInfo[1]), int.Parse(firstDateInfo[2]));
            var dateTwo = new DateTime(int.Parse(secondDateInfo[0]), int.Parse(secondDateInfo[1]), int.Parse(secondDateInfo[2]));

            var timeSpan = dateOne - dateTwo;
            double result = Math.Abs(timeSpan.TotalDays);
            return result;
        }
    }
}
