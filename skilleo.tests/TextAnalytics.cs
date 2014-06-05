using Microsoft.VisualStudio.TestTools.UnitTesting;
using skilleo.challenges;

namespace skilleo.tests
{
    [TestClass]
    public class TextAnalytics
    {
        /*
         *  Output string: Number of words, letters, symbols, words used more than once, letters used more than two times, words used once.
         *
         */

        [TestMethod]
        public void SkilleoSampleInput1_ShouldWorkAsExpected()
        {
            var result = new TextAnalyticsChallenge().ProcessInput("Some small sample text!");

            Assert.AreEqual("4, 19, 1, 0, 4, 4", result);
        }

        [TestMethod]
        public void SkilleoSampleInput2_ShouldWorkAsExpected()
        {
            var result = new TextAnalyticsChallenge().ProcessInput("Skilleo is cool");

            Assert.AreEqual("3, 13, 0, 0, 2, 3", result);
        }

        [TestMethod]
        public void SkilleoSampleInput3_ShouldWorkAsExpected()
        {
            var result = new TextAnalyticsChallenge().ProcessInput("Donec sollicitudin molestie malesuada. Donec rutrum congue leo eget malesuada.");

            Assert.AreEqual("10, 67, 2, 2, 12, 6", result);
        }

        [TestMethod]
        public void InputWithRepeatedWords_ShouldBeCountedCorrectly()
        {
            var result = new TextAnalyticsChallenge().ProcessInput("Word word word.");

            Assert.AreEqual("3, 12, 1, 1, 4, 0", result);
        }

        [TestMethod]
        public void InputWithQuote_ShouldBeCountedCorrectly()
        {
            var result = new TextAnalyticsChallenge().ProcessInput("'To be, or not to be. That is the question.'");

            Assert.AreEqual("10, 30, 5, 2, 3, 6", result);
        }
    }
}
