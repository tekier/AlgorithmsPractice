using System;
using API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class MoveParserShould
    {
        [TestCase("0 0 X", Moves.X)]
        [TestCase("0 0 O", Moves.O)]
        public void ParseMoveCorrectly(string input, Moves expectedMove)
        {
            Moves parsedMove = MoveParser.ExtractMove(input);
            parsedMove.Should().Be(expectedMove);
        }

        [TestCase("0 0 X", (ushort)0, (ushort)0)]
        public void ParseCoordinatesCorrectly(string input, ushort row, ushort column)
        {
            Tuple<ushort, ushort> calculatedCoordinates = MoveParser.GetCoordinates(input);
            calculatedCoordinates.Should().Be(new Tuple<ushort, ushort>(row, column));
        }

    }
}
