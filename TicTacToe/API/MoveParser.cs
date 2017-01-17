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

        public static Tuple<ushort, ushort> GetCoordinates(string userInput)
        {
            string stringWithWhiteSpacesRemoved = GetRidOfWhiteSpaces(userInput);
            ushort row = ushort.Parse(stringWithWhiteSpacesRemoved[0].ToString());
            ushort column = ushort.Parse(stringWithWhiteSpacesRemoved[1].ToString());
            return new Tuple<ushort, ushort>(row, column);
        }

        private static string GetRidOfWhiteSpaces(string inputString)
        {
            return inputString.Replace(" ", string.Empty);
        }
    }
}
