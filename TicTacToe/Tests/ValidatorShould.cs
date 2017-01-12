using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ValidatorShould
    {
        private Validator _validatorObject;

        [SetUp]
        public void SetUp()
        {
            _validatorObject = new Validator();
        }

        [TestCase("0 0 X")]
        [TestCase("1 1 X")]
        [TestCase("2 2 O")]
        public void ValidateCorrectlyFormattedUserInputs(string userInput)
        {
            bool isValid = _validatorObject.ValidateInput(userInput);
            isValid.Should().BeTrue();
        }

        [TestCase("red")]
        [TestCase("asdflj")]
        [TestCase("8 8 9")]
        [TestCase("5 5 O")]
        public void InvalidateIncorrectlyFormattedUserInputs(string userInput)
        {
            bool isValid = _validatorObject.ValidateInput(userInput);
            isValid.Should().BeFalse();
        }

    }

}
