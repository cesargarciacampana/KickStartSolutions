namespace RoundH.Tests
{
	public class RunningInCircles
	{
		[SetUp]
		public void Setup()
		{
		}

		static IOHelper[] testCases = new IOHelper[]
{
			new IOHelper(
 @"2
5 3
8 C
3 C
6 C
8 4
5 C
9 C
8 C
20 C",
@"Case #1: 3
Case #2: 5
"),

			new IOHelper(
 @"3
5 3
8 C
4 A
5 C
4 5
2 C
8 A
3 A
5 C
8 A
4 3
3 C
2 A
5 C",
@"Case #1: 1
Case #2: 5
Case #3: 1
"),

			new IOHelper(
 @"5
5 3
8 C
3 A
6 A
8 4
5 C
9 A
8 A
20 C
4 7
2 C
2 C
2 C
2 C
2 C
2 C
2 C
8 2
20 C
28 C
5 3
8 C
2 A
5 C",
@"Case #1: 2
Case #2: 3
Case #3: 3
Case #4: 6
Case #5: 2
"),

				new IOHelper(
 @"1
1000000000 3
100000000 C
100000000 C
100000000 C",
@"Case #1: 0
"),


};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void RunningInCirclesTest(IOHelper testCase)
		{
			RoundH.Program.RunningInCircles(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}