using FluentAssertions;
using NUnit.Framework;
using Strings;

namespace StringsTests
{
    [TestFixture]
    public class DoesTheStringHaveAllUniqueCharactersShould
    {
        private DoesTheStringHaveAllUniqueCharacters _uniquityChecker = new DoesTheStringHaveAllUniqueCharacters();

        [TestCase("abcde", true)]
        [TestCase("abcdedf", false)]
        public void CorrectlyCompleteCheckByExhaustiveSearch(string input, bool expectedOutput)
        {
            bool actualOutput = _uniquityChecker.CheckExhaustively(input);
            (actualOutput == expectedOutput).Should().BeTrue();
        }

        [TestCase("abcd", true)]
        [TestCase("afera", false)]
        public void CorrectlyCompleteCheckByHashtableLookUp(string input, bool expectedOutput)
        {
            bool actualOutput = _uniquityChecker.CheckUsingHashTable(input);
            (actualOutput == expectedOutput).Should().BeTrue();
        }

        [TestCase("abscfetk", true)]
        [TestCase("asdfasdf", false)]
        [TestCase("asdofasdfasdfasdfasdfioasdfioawuofiasdfasdfasdiomfiovnasdifasdijfasidfdnjcnas", false)]
        [TestCase("abcdefghijkl325';]", true)]
        [TestCase("[]#'/.,;*9*", false)]
        public void CorrectlyCompleteCheckByBitVector(string input, bool expectedOutput)
        {
            bool actualOutput = _uniquityChecker.CheckUsingBitVector(input);
            (actualOutput == expectedOutput).Should().BeTrue();
        }

        [TestCase("abcdefghijkl", true)]
        [TestCase("aberthiuqwlrpoz", false)]
        public void CorrectlyCompleteCheckByUsingSortedAdjacencySearch(string input, bool expectedOutput)
        {
            bool actualOutput = _uniquityChecker.CheckingUsingSortedAdjacencySearch(input);
            (actualOutput == expectedOutput).Should().BeTrue();
        }
    }
}
