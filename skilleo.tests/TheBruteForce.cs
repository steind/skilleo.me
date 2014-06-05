using Microsoft.VisualStudio.TestTools.UnitTesting;
using skilleo.challenges;

namespace skilleo.tests
{
    [TestClass]
    public class TheBruteForce
    {
        [TestMethod]
        public void SkilleoSampleInput_ShouldWorkAsExpected()
        {
            const string hash = "81b5dd04bf5cbc172eeb34bb8062fde1";

            var output = new TheBruteForceChallenge().ProcessInput(hash);

            Assert.AreEqual("a23c", output);
        }
    }
}
