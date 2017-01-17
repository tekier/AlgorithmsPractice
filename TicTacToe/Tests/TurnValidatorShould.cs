using System;
using API;
using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;
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

        [Test]
        public void DetectCurrentMoveIsNotOverwrite()
        {
            MoveCategory actualError = TurnValidator.CurrentMoveIsOverwrite(new Tuple<ushort, ushort>(0, 0));
            actualError.Should().Be(MoveCategory.MoveIsValid);
        }

        [Test]
        public void DetectCurrentMoveIsOverwrite()
        {
            //setup:
            GridUpdater.InsertIntoGrid(new Tuple<ushort, ushort>(1,1), Moves.O);
            //act
            MoveCategory actualError = TurnValidator.CurrentMoveIsOverwrite(new Tuple<ushort, ushort>(1, 1));
            //assert
            actualError.Should().Be(MoveCategory.PositionAlreadyFilledError);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(3)]
        public void DetectGameIsNotExhausted(int numberOfMovesInContext)
        {
            TurnValidator.HasNotDrawnYet(numberOfMovesInContext).Should().BeTrue();
        }

        [TestCase(10)]
        public void DetectGameIsExhausted(int numberOfMovesInContext)
        {
            TurnValidator.HasNotDrawnYet(numberOfMovesInContext).Should().BeFalse();
        }
    }
}
