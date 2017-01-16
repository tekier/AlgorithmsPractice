using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WinCheckShould
    {
        [TestCase(
             new[]
             {
                 Moves.X, Moves.X, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectWinCorrectlyForHorizantalXInputFirstThree(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.O, Moves.O, Moves.O, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectWinCorrectlyForHorizantalOInputFirstThree(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.O, Moves.O, Moves.O, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectLossCorrectlyForHorizantalOInput1(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeFalse();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.X, Moves.X, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectLossCorrectlyForHorizantalXInput1(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeFalse();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.X, Moves.X, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectWinCorrectlyForHorizantalXInput2(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.O, Moves.X, Moves.X, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectLossCorrectlyForHorizantalMixedInput2(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeFalse();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.X, Moves.X, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectLossCorrectlyForHorizantalXInput3(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeFalse();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.X,
                 Moves.X
             })]
        public void DetectWinCorrectlyForHorizantalXInput3(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.X, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectWinCorrectlyFoVerticalXInput1(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.O, Moves.Blank, Moves.Blank, Moves.O, Moves.Blank, Moves.Blank, Moves.O,
                 Moves.Blank
             })]
        public void DetectWinCorrectlyFoVerticalOInput2(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.X, Moves.X, Moves.O, Moves.O, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectLossCorrectlyFoVerticalMixedInput(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeFalse();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank,
                 Moves.X
             })]
        public void DetectWinCorrectlyFoVerticalXInput3(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.X
             })]
        public void DetectWinCorrectlyFoDiagonalXInput1(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

        [TestCase(
             new[]
             {
                 Moves.Blank, Moves.Blank, Moves.O, Moves.Blank, Moves.O, Moves.Blank, Moves.O, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectWinCorrectlyFoDiagonalOInput2(Moves[] input, Moves mockLastMove = Moves.None)
        {
            var what = WinChecker.HasWon(input, mockLastMove);
            what.Should().BeTrue();
        }

    }
}
