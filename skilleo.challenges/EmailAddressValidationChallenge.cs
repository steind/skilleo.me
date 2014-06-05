namespace skilleo.challenges
{
    public class EmailAddressValidationChallenge : Challenge
    {
        public override string ProcessInput(string input)
        {
            var result = ValidString;

            if (input.Contains(" "))
            {
                // input must not contain spaces
                result = InvalidString;
            }

            return result;
        }
    }
}
