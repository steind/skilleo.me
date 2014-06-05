using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace skilleo.tests
{
    [TestClass]
    public class MultiOperationCalculator
    {
        [TestMethod]
        public void SkilleoSampleInput1_ShouldWorkAsExpected()
        {
            const string input = "15 + 2 - 4 + 2";

            Assert.AreEqual("15", new challenges.MultiOperationCalculator().ProcessInput(input));
        }

        [TestMethod]
        public void SkilleoSampleInput2_ShouldWorkAsExpected()
        {
            const string input = "-4 / 2 + 2";

            Assert.AreEqual("0", new challenges.MultiOperationCalculator().ProcessInput(input));
        }
    }
}
