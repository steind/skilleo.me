using Microsoft.VisualStudio.TestTools.UnitTesting;
using skilleo.challenges;

namespace skilleo.tests
{
    [TestClass]
    public class ThePasswordStrength
    {
        [TestMethod]
        public void SampleInputs_ShouldWorkAsExpected()
        {
            const string sampleInput1 = "mypassword123";
            const string sampleInput2 = "#Some_Pass1#";

            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput(sampleInput1) == Challenge.InvalidString);
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput(sampleInput2) == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordLessThanSixCharacters_ShouldBeInvalid()
        {
            const string password = "abcde";

            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput(password) == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordEqualToSixCharacters_ShouldBeValid()
        {
            const string password = "Ab$d3f";

            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput(password) == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordGreaterThanSixCharacters_ShouldBeValid()
        {
            const string password = "abd3fghI$";

            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput(password) == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithOneCapitalLetter_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("a$Cd3f") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithoutCapitalLetter_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("abcdef") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithoutLetter_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("123456") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithOneLetter_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("123C45$") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithSpace_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abc def1") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithTab_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abc     def1") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithoutNumber_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcdef") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithOneNumber_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("$Abcde0") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithMoreThanOneNumber_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("$A0cde0") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithoutDollarSign_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3f") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithDollarSign_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3$f") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithoutPoundSign_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3f") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithPoundSign_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3#f") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithoutDash_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3f") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithDash_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3-f") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithoutUnderscore_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3f") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithUnderscore_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3_f") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithoutAmpersand_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3f") == Challenge.InvalidString);
        }

        [TestMethod]
        public void PasswordWithAmpersand_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("Abcd3&f") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithMultipleSymbols_ShouldBeValid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("0cC_$&-#") == Challenge.ValidString);
        }

        [TestMethod]
        public void PasswordWithoutSymbol_ShouldBeInvalid()
        {
            Assert.IsTrue(new challenges.ThePasswordStrength().ProcessInput("0Aa12345") == Challenge.InvalidString);
        }
    }
}
