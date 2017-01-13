using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ValidatorShould
    {

        [TestCase("0 0 X")]
        [TestCase("1 1 X")]
        [TestCase("2 2 O")]
        public void ValidateCorrectlyFormattedUserInputs(string userInput)
        {
            var isValid = MoveValidator.ValidateInput(userInput);
            isValid.Should().Be(InvalidMove.MoveIsValid);
        }

        [TestCase("red")]
        [TestCase("asdflj")]
        [TestCase("8 8 9")]
        [TestCase("5 5 O")]
        [TestCase("R W X")]
        [TestCase("")]
        public void InvalidateIncorrectlyFormattedUserInputs(string userInput)
        {
            var isValid = MoveValidator.ValidateInput(userInput);
            isValid.Should().Be(InvalidMove.IncorrectFormatError);
        }

    }

}
