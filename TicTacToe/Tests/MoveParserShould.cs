using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MoveParserShould
    {
        [TestCase("0 0 X", Moves.X)]
        [TestCase("0 0 O", Moves.O)]
        public void ParseMoveCorrectly(string input, Moves expectedMove)
        {
            Moves parsedMove = MoveParser.ExtractMove(input);
            parsedMove.Should().Be(expectedMove);
        }

    }
}
