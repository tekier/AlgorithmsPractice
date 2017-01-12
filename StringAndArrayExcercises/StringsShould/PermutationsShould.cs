using FluentAssertions;
using NUnit.Framework;
using Strings;

namespace StringsTests
{
    [TestFixture]
    public class PermutationsShould
    {
        private Permutations _permutator = new Permutations();

        [TestCase("", new[] {" "})]
        public void GetAllPermutationsOfEmptyString(string input, string[] expectedOutputStrings)
        {
            var actualOutput = _permutator.GetPermutationsOf(input);
            actualOutput.Should().BeEquivalentTo(expectedOutputStrings);
        }

        [TestCase("a", new[] {"a"})]
        public void GetAllPermutationsOfSingleCharacter(string input, string[] expectedOutputStrings)
        {
            var actualOutput = _permutator.GetPermutationsOf(input);
            actualOutput.Should().BeEquivalentTo(expectedOutputStrings);
        }

        [TestCase("ab", new[] {"ab","ba"})]
        [TestCase("xy", new[] {"xy", "yx"})]
        public void GetAllPermutationsOfDoubleCharacterString(string input, string[] expectedOutputStrings)
        {
            var actualOutput = _permutator.GetPermutationsOf(input);
            actualOutput.Should().BeEquivalentTo(expectedOutputStrings);
        }

        [TestCase("rad", new[] {"rad", "rda", "ard", "adr", "dar", "dra"})]
        [TestCase("you", new[] {"yuo","you","uoy","uyo","ouy","oyu"})]
        public void GetAllPermutationsOfThreeCharacterString(string input, string[] expectedOutputStrings)
        {
            var actualOutput = _permutator.GetPermutationsOf(input);
            actualOutput.Should().BeEquivalentTo(expectedOutputStrings);
        }
    }
}
