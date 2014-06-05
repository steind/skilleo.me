using Microsoft.VisualStudio.TestTools.UnitTesting;
using skilleo.challenges;

namespace skilleo.tests
{
    [TestClass]
    public class EmailAddressValidation
    {
        [TestMethod]
        public void SampleInput1_ShouldBeInvalid()
        {
            var output = new EmailAddressValidationChallenge().ProcessInput("random text");

            Assert.IsTrue(output == Challenge.InvalidString);
        }

        [TestMethod]
        public void SampleInput2_ShouldBeValid()
        {
            var output = new EmailAddressValidationChallenge().ProcessInput("some_name@email.com");

            Assert.IsTrue(output == Challenge.ValidString);
        }
    }
}
