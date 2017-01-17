using System;

namespace API
{
    internal static class TurnValidator
    {
        public static MoveCategory ThisMoveIsNotSameAsLastMove(Moves lastMove, Moves thisMove)
        {
            if (lastMove == thisMove)
            {
                Console.WriteLine("\nIts not your turn. Other player go... ");
                return MoveCategory.SameMoveAsPreviousMoveError;
            }
            return MoveCategory.MoveIsValid;
        }

        public static MoveCategory CurrentMoveIsOverwrite(Tuple<ushort, ushort> positionOnGrid)
        {
            if (GridUpdater.GetValueAt(positionOnGrid) != Moves.Blank)
            {
                Console.WriteLine("\nThat position is filled, try one of the blanks...\n");
                return MoveCategory.PositionAlreadyFilledError;
            }
            return MoveCategory.MoveIsValid;
        }

        public static bool HasNotDrawnYet(int numberOfTurns)
        {
            if (numberOfTurns < 10)
                return true;
            Console.WriteLine("\nDraw!\n");
            return false;
        }
    }
}
