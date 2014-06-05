using Microsoft.VisualStudio.TestTools.UnitTesting;
using skilleo.challenges;

namespace skilleo.tests
{
    [TestClass]
    public class DateValidator
    {
        private const string ValidString = "Valid";
        private const string InvalidString = "Invalid";

        [TestMethod]
        public void InputWithLessThanTwoDates_ShouldBeInvalid()
        {
            const string input = "12/23/2013";

            var output = DateValidatorChallenge.ProcessInput(input);

            Assert.IsTrue(output == InvalidString);
        }

        [TestMethod]
        public void InputWithMoreThanTwoDates_ShouldBeInvalid()
        {
            const string input = "12/23/2013 - 10/01/2014 - 12/31/2014";

            var output = DateValidatorChallenge.ProcessInput(input);

            Assert.IsTrue(output == InvalidString);
        }

        [TestMethod]
        public void InputWithFirsDateBeforeSecondDate_ShouldBeValid()
        {
            const string input = "12/23/2013 - 10/01/2014";

            var output = DateValidatorChallenge.ProcessInput(input);

            Assert.IsTrue(output == ValidString);
        }

        [TestMethod]
        public void InputWithFirsDateEqualToSecondDate_ShouldBeInvalid()
        {
            const string input = "12/23/2013 - 12/23/2013";

            var output = DateValidatorChallenge.ProcessInput(input);

            Assert.IsTrue(output == InvalidString);
        }

        [TestMethod]
        public void InputWithFirsDateAfterToSecondDate_ShouldBeInvalid()
        {
            const string input = "12/23/2013 - 12/23/2010";

            var output = DateValidatorChallenge.ProcessInput(input);

            Assert.IsTrue(output == InvalidString);
        }

        [TestMethod]
        public void InputWithWrongFormattedDate_ShouldBeInvalid()
        {
            const string input = "11/22/2013 - 23/01/2015";

            var output = DateValidatorChallenge.ProcessInput(input);

            Assert.IsTrue(output == InvalidString);
        }

    }
}
