using System;

namespace API
{
    public static class Game
    {
        private static Moves _lastMove = Moves.None;
        private static short _numberOfTurns = 0;

        public static bool HasNotBeenWon()
        {
            var gridToCheckWin = GridUpdater.GetGrid();
            return !WinChecker.HasWon(gridToCheckWin, _lastMove);
        }

        public static bool HasNotBeenDrawn()
        {
            if (TurnValidator.HasNotDrawnYet(_numberOfTurns))
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
            if (TurnValidator.ThisMoveIsNotSameAsLastMove(_lastMove, moveToAdd) == MoveCategory.MoveIsValid &&
                TurnValidator.CurrentMoveIsOverwrite(positionOnGrid) == MoveCategory.MoveIsValid)
            {
                GridUpdater.InsertIntoGrid(positionOnGrid, moveToAdd);
                _lastMove = moveToAdd;
                _numberOfTurns++;
            }
        }

        public static void PrintGrid()
        {
            GridUpdater.PrettyPrint();
        }

        public static int GetNumberOfMoves()
        {
            return _numberOfTurns;
        }

        public static bool ValidateInput(string userInput)
        {
            if (MoveValidator.ValidateInput(userInput) == MoveCategory.IncorrectFormatError) return true;
            return false;
        }
    }
}
