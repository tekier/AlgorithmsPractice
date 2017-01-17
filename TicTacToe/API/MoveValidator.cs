using System.Linq;
using static System.Configuration.ConfigurationManager;

namespace API
{
    internal static class MoveValidator
    {
        private static readonly ushort CorrectNumberOfInputElements = ushort.Parse(AppSettings["number of input elements"]);
        private static readonly ushort MaxRangeOfInputElements = ushort.Parse(AppSettings["max range"]);

        public static MoveCategory ValidateInput(string userInput)
        {
            var toCheck = userInput.Replace(" ", string.Empty);
            return IsCorrectLength(toCheck) && FirstTwoEntriesAreCastableAsShorts(toCheck) &&
                   LastElementOfUserInputIsXorO(toCheck) && FirstTwoEntriesAreInRange(toCheck)
                ? MoveCategory.MoveIsValid
                : MoveCategory.IncorrectFormatError;
        }

        private static bool FirstTwoEntriesAreInRange(string toCheck)
        {
            var firstElementLessThanMaxValue = ushort.Parse(toCheck[0].ToString()) <= MaxRangeOfInputElements;
            var secondElementLessThanMaxValue = ushort.Parse(toCheck[1].ToString()) <= MaxRangeOfInputElements;
            return firstElementLessThanMaxValue && secondElementLessThanMaxValue;
        }

        private static bool LastElementOfUserInputIsXorO(string toCheck)
        {
            var lastElement = toCheck.Last().ToString();
            return lastElement.Equals("X") || lastElement.Equals("O");
        }

        private static bool FirstTwoEntriesAreCastableAsShorts(string toCheck)
        {
            var firstElementIsNumber = char.IsDigit(toCheck[0]);
            var secondElementIsNumber = char.IsDigit(toCheck[1]);
            return firstElementIsNumber && secondElementIsNumber;
        }

        private static bool IsCorrectLength(string toCheck)
        {
            return toCheck.Length == CorrectNumberOfInputElements;
        }
    }
}
