using System;

namespace DateModifier
{
    public class DateModifier
    {
        public static int GetDifferenceInDays(string start, string end)
        {
            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);

            TimeSpan difference = startDate - endDate;

            return Math.Abs(difference.Days);
        }
    }
}


