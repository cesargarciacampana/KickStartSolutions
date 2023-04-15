namespace RoundA.Tests
{
	public class IlluminationOptimization
	{
		[SetUp]
		public void Setup()
		{
		}

		static IOHelper[] testCases = new IOHelper[]
{
			new IOHelper(
 @"3
10 3 3
2 7 9
10 2 3
2 7 9
10 2 4
2 3 7 9",
@"Case #1: 2
Case #2: IMPOSSIBLE
Case #3: 4
"),

			new IOHelper(
			 @"4
10 3 3
2 3 4
10 3 3
5 6 7
10 4 3
4 5 6
4 1 3
1 2 3",
@"Case #1: IMPOSSIBLE
Case #2: IMPOSSIBLE
Case #3: 2
Case #4: 2
")

};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void IlluminationOptimizationTest(IOHelper testCase)
		{
			RoundA.Program.IlluminationOptimization(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}