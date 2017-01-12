using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Strings;

namespace StringsTests
{
    [TestFixture]
    public class ReplaceSpacesWithStringShould
    {
        private ReplaceSpacesWithString _replacer = new ReplaceSpacesWithString();

        [TestCase("example string", "example_string")]
        public void ReplaceCorrectlyWhenUsingStringbuilder(string withSpaces, string expectedOutputString)
        {
           _replacer.ReplaceUsingStringBuilder(ref withSpaces);
            withSpaces.Should().Be(expectedOutputString);
        }

        [TestCase("example string", "example_string")]
        public void ReplaceCorrectlyWhenUsingBasicArrayOperations(string withSpaces, string expectedOutputString)
        {
           _replacer.ReplaceUsingBasicStringOps(ref withSpaces);
            withSpaces.Should().Be(expectedOutputString);
        }
            
    }
}
