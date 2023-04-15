namespace RoundA.Tests
{
	public class AsciiArt
	{
		[SetUp]
		public void Setup()
		{
		}

		static IOHelper[] testCases = new IOHelper[]
{
			new IOHelper(
 @"2
5
31",
@"Case #1: E
Case #2: C
")

};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void AsciiArtTest(IOHelper testCase)
		{
			RoundA.Program.AsciiArt(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}