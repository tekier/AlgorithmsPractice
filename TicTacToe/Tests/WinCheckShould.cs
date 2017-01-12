using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WinCheckShould
    {
        private WinChecker _checker;

        [SetUp]
        public void SetUp()
        {
            _checker = new WinChecker();
        }

        [TestCase(
             new[]
             {
                 Moves.X, Moves.X, Moves.X, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(
             new[]
             {
                 Moves.O, Moves.O, Moves.O, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        [TestCase(
             new[]
             {
                 Moves.X, Moves.O, Moves.O, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank, Moves.Blank,
                 Moves.Blank
             })]
        public void DetectWinCorrectly(Moves[] input)
        {
            var what = _checker.HasWon(input);
            what.Should().BeTrue();
        }
    }
}
