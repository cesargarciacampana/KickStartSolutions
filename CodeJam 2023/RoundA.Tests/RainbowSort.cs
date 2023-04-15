namespace RoundA.Tests
{
	public class RainbowSort
	{
		[SetUp]
		public void Setup()
		{
		}

		static IOHelper[] testCases = new IOHelper[]
{
			new IOHelper(
 @"2
4
3 8 8 2
5
3 8 2 2 8",
@"Case #1: 3 8 2
Case #2: IMPOSSIBLE
")

};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void RainbowSortTest(IOHelper testCase)
		{
			RoundA.Program.RainbowSort(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}