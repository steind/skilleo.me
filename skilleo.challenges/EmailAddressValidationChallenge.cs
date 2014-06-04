namespace skilleo.challenges
{
    public class EmailAddressValidationChallenge
    {
        public static string ProcessInput(string input)
        {
            var result = "Valid";

            if (input.Contains(" "))
            {
                // input must not contain spaces
                result = "Invalid";
            }

            return result;
        }
    }
}
