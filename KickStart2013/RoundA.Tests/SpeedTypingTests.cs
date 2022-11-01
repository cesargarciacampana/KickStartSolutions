using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace RoundA.Tests
{
    public class SpeedTypingTests
    {
        [SetUp]
        public void Setup()
        {
        }

        static IOHelper[] testCases = new IOHelper[]
        {
            new IOHelper(
 @"2
aaaa
aaaaa
bbbbb
bbbbc",
@"Case #1: 1
Case #2: IMPOSSIBLE
"),

            new IOHelper(
 @"2
Ilovecoding
IIllovecoding
KickstartIsFun
kkickstartiisfun",
@"Case #1: 2
Case #2: IMPOSSIBLE
"),

            new IOHelper(
 @"2
Cesar
Cesar
Garcia
Garci",
@"Case #1: 0
Case #2: IMPOSSIBLE
"),

            new IOHelperFromFile(@"C:\Users\César\Downloads\test_data (3)\test_set_1\ts1_input.txt", @"C:\Users\César\Downloads\test_data (3)\test_set_1\ts1_output.txt"),
        };

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void SpeedTypingTest(IOHelper testCase)
        {
            RoundA.Program.SpeedTyping(testCase);

            Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
        }
    }
}