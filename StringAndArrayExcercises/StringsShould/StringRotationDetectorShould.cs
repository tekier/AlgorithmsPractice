using FluentAssertions;
using NUnit.Framework;
using Strings;

namespace StringsTests
{
    [TestFixture]
    public class StringRotationDetectorShould
    {
        private StringRotationDetector _detector = new StringRotationDetector();

        [TestCase("examplestring", "lestringexamp")]
        [TestCase("a", "a")]
        [TestCase("tree", "etre")]
        public void DetectRotatedString(string baseString, string rotatedString)
        {
            (_detector.CheckRotation(baseString, rotatedString)).Should().BeTrue();
        }

        [TestCase("exazmplestring", "lestringexamp")]
        [TestCase("a", "")]
        [TestCase("treee", "etre")]
        public void FailToDetectRotatedString(string baseString, string rotatedString)
        {
            (_detector.CheckRotation(baseString, rotatedString)).Should().BeFalse();
        }
    }
}
