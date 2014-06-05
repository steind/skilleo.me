using System;
using System.Globalization;

namespace skilleo.challenges
{
    public class DateValidatorChallenge : Challenge
    {
        public override string ProcessInput(string input)
        {
            var dates = input.Split('-');
            DateTime date1;
            DateTime date2;

            // input must contain 2 dates
            if (dates.Length != 2)
            {
                return InvalidString;
            }

            // dates must be valid dates in the format mm/dd/yyyy.
            if (!DateTime.TryParseExact(dates[0].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date1))
            {
                return InvalidString;
            }

            if (!DateTime.TryParseExact(dates[1].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date2))
            {
                return InvalidString;
            }

            // date1 must be before date2
            return date1 < date2 ? ValidString : InvalidString;
        }
    }
}
