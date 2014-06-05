using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace skilleo.challenges
{
    public class TheBruteForceChallenge : Challenge
    {
        public override string ProcessInput(string input)
        {
            var allowedCharacters = new[] { 'a', 'b', 'c', '0', '1', '2', '3' };

            var md5 = MD5.Create();

            for (var a = 0; a < allowedCharacters.Count(); a++)
            {
                for (var b = 0; b < allowedCharacters.Count(); b++)
                {
                    for (var c = 0; c < allowedCharacters.Count(); c++)
                    {
                        for (var d = 0; d < allowedCharacters.Count(); d++)
                        {
                            // guess represents an array of bytes from allowedCharacters.
                            var guessBytes = Encoding.UTF8.GetBytes(new[]
                            {
                                allowedCharacters[a], 
                                allowedCharacters[b], 
                                allowedCharacters[c], 
                                allowedCharacters[d]
                            });

                            // Compute a hash for guess.
                            var guessHash = md5.ComputeHash(guessBytes);

                            // Convert the bytes of the hashed guess to a hex string.
                            var guessHashHexString = new StringBuilder();
                            foreach (var b1 in guessHash)
                            {
                                guessHashHexString.Append(b1.ToString("x2"));
                            }

                            // Does the hash value of the guess match the input hash?
                            if (guessHashHexString.ToString() == input)
                            {
                                return Encoding.UTF8.GetString(guessBytes);
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
