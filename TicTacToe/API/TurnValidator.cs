using System;

namespace API
{
    public static class TurnValidator
    {
        private static int _numberOfTurnsSoFar;

        public static InvalidMove ThisMoveIsNotSameAsLastMove(Moves lastMove, Moves thisMove)
        {
            if (lastMove == thisMove)
            {
                Console.WriteLine("\nIts not your turn. Other player go... ");
                return InvalidMove.SameMoveAsPreviousMoveError;
            }
            _numberOfTurnsSoFar++;
            return InvalidMove.MoveIsValid;
        }

        public static int GetNumberOfMovesSoFar()
        {
            return _numberOfTurnsSoFar;
        }

        public static bool CurrentMoveIsOverwrite(Tuple<short, short> positionOnGrid)
        {
            if (GridUpdater.GetValueAt(positionOnGrid) != Moves.Blank)
            {
                Console.WriteLine("\nThat position is filled, try one of the blanks...\n");
                return true;
            }
            return false;
        }
    }
}
