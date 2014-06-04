using Microsoft.VisualStudio.TestTools.UnitTesting;
using skilleo.challenges;

namespace skilleo.tests
{
    [TestClass]
    public class EmailAddressValidation
    {
        private const string ValidString = "Valid";
        private const string InvalidString = "Invalid";

        [TestMethod]
        public void SampleInput1_ShouldBeInvalid()
        {
            const string input = "random text";
            var output = EmailAddressValidationChallenge.ProcessInput(input);

            Assert.IsTrue(output == InvalidString);
        }

        [TestMethod]
        public void SampleInput2_ShouldBeValid()
        {
            const string input = "some_name@email.com";
            var output = EmailAddressValidationChallenge.ProcessInput(input);

            Assert.IsTrue(output == ValidString);
        }
    }
}
