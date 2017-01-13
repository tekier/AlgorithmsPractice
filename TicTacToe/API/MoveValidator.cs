using System.Linq;
using static System.Configuration.ConfigurationManager;

namespace API
{
    public static class MoveValidator
    {
        private static readonly int CorrectNumberOfInputElements = short.Parse(AppSettings["number of input elements"]);
        private static readonly int MaxRangeOfInputElements = short.Parse(AppSettings["max range"]);

        public static InvalidMove ValidateInput(string userInput)
        {
            var userInputWithWhitespacesRemoved = userInput.Replace(" ", string.Empty);
            return IsCorrectLength(userInputWithWhitespacesRemoved) &&
                   FirstTwoEntriesAreCastableAsIntegers(userInputWithWhitespacesRemoved) &&
                   LastElementOfUserInputIsXorO(userInputWithWhitespacesRemoved) &&
                   FirstTwoEntriesAreInRange(userInputWithWhitespacesRemoved) ? InvalidMove.MoveIsValid : InvalidMove.IncorrectFormatError;
        }
        private static bool FirstTwoEntriesAreInRange(string userInputWithWhitespacesRemoved)
        {
            var firstElementLessThanMaxValue = short.Parse(userInputWithWhitespacesRemoved[0].ToString()) <=
                                               MaxRangeOfInputElements;
            var secondElementLessThanMaxValue = short.Parse(userInputWithWhitespacesRemoved[1].ToString()) <=
                                                MaxRangeOfInputElements;
            return firstElementLessThanMaxValue && secondElementLessThanMaxValue;
        }
        private static bool LastElementOfUserInputIsXorO(string userInputWithWhitespacesRemoved)
        {
            var lastElement = userInputWithWhitespacesRemoved.Last().ToString();
            return lastElement.Equals("X") || lastElement.Equals("O");
        }
        private static bool FirstTwoEntriesAreCastableAsIntegers(string userInputWithWhitespacesRemoved)
        {
            var firstElementIsNumber = char.IsDigit(userInputWithWhitespacesRemoved[0]);
            var secondElementIsNumber = char.IsDigit(userInputWithWhitespacesRemoved[1]);
            return firstElementIsNumber && secondElementIsNumber;
        }
        private static bool IsCorrectLength(string userInputWithNoWhitespace)
        {
            return userInputWithNoWhitespace.Length == CorrectNumberOfInputElements;
        }
    }
}
