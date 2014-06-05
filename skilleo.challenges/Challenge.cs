namespace skilleo.challenges
{
    public abstract class Challenge
    {
        public const string ValidString = "Valid";
        public const string InvalidString = "Invalid";
        public abstract string ProcessInput(string input);
    }
}
