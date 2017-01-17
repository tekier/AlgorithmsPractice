using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace API
{
    public static class Game
    {
        private static Moves _lastMove = Moves.None;
        public static short NumberOfTurns { get; private set; }

        public static bool HasNotBeenWon()
        {
            var gridToCheckWin = GridUpdater.GetGrid();
            return !WinChecker.HasWon(gridToCheckWin, _lastMove);
        }

        public static bool HasNotBeenDrawn()
        {
            if (TurnValidator.HasNotDrawnYet(NumberOfTurns))
                return true;
            return false;
        }

        public static void Apply(string userInput)
        {
            Moves moveToAdd = MoveParser.ExtractMove(userInput);
            Tuple<short, short> positionOnGrid = MoveParser.GetCoordinates(userInput);
            CheckMoveIsValidAndUpdateGrid(moveToAdd, positionOnGrid);
        }

        private static void CheckMoveIsValidAndUpdateGrid(Moves moveToAdd, Tuple<short, short> positionOnGrid)
        {
            if (TurnValidator.ThisMoveIsNotSameAsLastMove(_lastMove, moveToAdd) == MoveCategory.MoveIsValid && TurnValidator.CurrentMoveIsOverwrite(positionOnGrid) == MoveCategory.MoveIsValid)
            {
                GridUpdater.InsertIntoGrid(positionOnGrid, moveToAdd);
                _lastMove = moveToAdd;
                NumberOfTurns++;
            }
        }

        public static void PrintGrid()
        {
            GridUpdater.PrettyPrint();
        }

        public static bool ValidateInput(string userInput)
        {
            if (MoveValidator.ValidateInput(userInput) == MoveCategory.IncorrectFormatError) return true;
            return false;
        }
    }
}
