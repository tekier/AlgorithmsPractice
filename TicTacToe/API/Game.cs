using System;
using System.Globalization;

namespace API
{
    public static class Game
    {
        private static Moves _lastMove = Moves.None;

        public static bool HasNotBeenWon()
        {
            var gridToCheckWin = GridUpdater.GetGrid();
            return !WinChecker.HasWon(gridToCheckWin, _lastMove);
        }
        public static bool HasNotBeenDrawn()
        {
            if (TurnValidator.GetNumberOfMovesSoFar() < 10)
                return true;
            Console.WriteLine("\nDraw!\n");
            return false;
        }
        public static void Apply(string userInput)
        {
            Moves moveToAdd = MoveParser.ExtractMove(userInput);
            Tuple<short, short> positionOnGrid = MoveParser.GetCoordinates(userInput);
            CheckAndUpdateGrid(moveToAdd, positionOnGrid);
        }
        private static void CheckAndUpdateGrid(Moves moveToAdd, Tuple<short, short> positionOnGrid)
        {
            if (TurnValidator.ThisMoveIsNotSameAsLastMove(_lastMove, moveToAdd) == InvalidMove.MoveIsValid &&
                !TurnValidator.CurrentMoveIsOverwrite(positionOnGrid))
            {
                GridUpdater.InsertIntoGrid(positionOnGrid, moveToAdd);
                _lastMove = moveToAdd;
            }
        }
        public static void PrintGrid()
        {
            Grid.PrettyPrint();
        }
        public static int GetNumberOfMoves()
        {
            return TurnValidator.GetNumberOfMovesSoFar();
        }
    }
}
