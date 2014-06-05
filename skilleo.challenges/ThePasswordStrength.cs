using System.Text.RegularExpressions;

namespace skilleo.challenges
{
    public class ThePasswordStrength : Challenge
    {
        public override string ProcessInput(string input)
        {
            // At least six characters
            if (input.Length < 6)
            {
                return InvalidString;
            }

            // No white spaces
            if (Regex.IsMatch(input, @"\s+"))
            {
                return InvalidString;
            }

            // At least one letter
            if (!Regex.IsMatch(input, @"[a-zA-Z]+"))
            {
                return InvalidString;
            }

            // At least one capital letter
            if (!Regex.IsMatch(input, @"[A-Z]+"))
            {
                return InvalidString;
            }

            // At least one number
            if (!Regex.IsMatch(input, @"[0-9]+"))
            {
                return InvalidString;
            }

            // At least one of: $ # - _ &
            if (!Regex.IsMatch(input, @"[$#\-_&]+"))
            {
                return InvalidString;
            }

            return ValidString;
        }
    }
}
