using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class TurnValidatorShould
    {
        [TestCase(Moves.X, Moves.X)]
        [TestCase(Moves.O, Moves.O)]
        public void CorrectlyDetectConsectiveMovesThatAreTheSame(Moves previousMove, Moves newMove)
        {
            MoveCategory areSame = TurnValidator.ThisMoveIsNotSameAsLastMove(previousMove, newMove);
            areSame.Should().Be(MoveCategory.SameMoveAsPreviousMoveError);
        }
        [TestCase(Moves.X, Moves.O)]
        [TestCase(Moves.O, Moves.X)]
        public void CorrectlyDetectConsectiveMovesThatAreTheDifferent(Moves previousMove, Moves newMove)
        {
            MoveCategory areSame = TurnValidator.ThisMoveIsNotSameAsLastMove(previousMove, newMove);
            areSame.Should().Be(MoveCategory.MoveIsValid);
        }
    }
}
