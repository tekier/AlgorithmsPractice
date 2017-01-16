using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TurnValidatorShould
    {
        [TestCase(Moves.X, Moves.X)]
        [TestCase(Moves.O, Moves.O)]
        public void CorrectlyDetectConsectiveMovesThatAreTheSame(Moves previousMove, Moves newMove)
        {
            InvalidMove areSame = TurnValidator.ThisMoveIsNotSameAsLastMove(previousMove, newMove);
            areSame.Should().Be(InvalidMove.SameMoveAsPreviousMoveError);
        }
        [TestCase(Moves.X, Moves.O)]
        [TestCase(Moves.O, Moves.X)]
        public void CorrectlyDetectConsectiveMovesThatAreTheDifferent(Moves previousMove, Moves newMove)
        {
            InvalidMove areSame = TurnValidator.ThisMoveIsNotSameAsLastMove(previousMove, newMove);
            areSame.Should().Be(InvalidMove.MoveIsValid);
        }
    }
}
