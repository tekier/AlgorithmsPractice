using System.Net;

namespace API
{
    public static class PlayerTracker
    {
        private static Moves _lastMove = Moves.X;
        private static int _numberOfTurnsSoFar;

        public static InvalidMove ThisMoveIsNotSameAsLastMove(Moves thisMove)
        {
            if(_lastMove == thisMove)
                return InvalidMove.SameMoveAsPreviousMoveError;
            _numberOfTurnsSoFar++;
            return InvalidMove.MoveIsValid;
        }

        public static int GetNumberOfMovesSoFar()
        {
            return _numberOfTurnsSoFar;
        }

    }
}
