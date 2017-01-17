using System;

namespace API
{
    internal static class MoveParser
    {
        public static Moves ExtractMove(string inputString)
        {
            string stringWithWhiteSpacesRemoved = GetRidOfWhiteSpaces(inputString);
            if (stringWithWhiteSpacesRemoved.EndsWith("O"))
                return Moves.O;
            return Moves.X;
        }

        public static Tuple<short,short> GetCoordinates(string userInput)
        {
            string stringWithWhiteSpacesRemoved = GetRidOfWhiteSpaces(userInput);
            short row = short.Parse(stringWithWhiteSpacesRemoved[0].ToString());
            short column = short.Parse(stringWithWhiteSpacesRemoved[1].ToString());
            return new Tuple<short, short>(row, column);
        }

        private static string GetRidOfWhiteSpaces(string inputString)
        {
            return inputString.Replace(" ", string.Empty);
        }
    }
}
