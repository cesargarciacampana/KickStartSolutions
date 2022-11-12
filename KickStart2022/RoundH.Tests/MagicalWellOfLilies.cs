namespace RoundH.Tests
{
	public class MagicalWellOfLilies
	{
		[SetUp]
		public void Setup()
		{
		}

		static IOHelper[] testCases = new IOHelper[]
{
//			new IOHelper(
// @"3
//1
//5
//20",
//@"Case #1: 1
//Case #2: 5
//Case #3: 15
//"),

						new IOHelper(
 @"1
20",
@"Case #1: 15
"),

			new IOHelper(
	 @"15
9
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16",
@"Case #1: 9
Case #2: 2
Case #3: 3
Case #4: 4
Case #5: 5
Case #6: 6
Case #7: 7
Case #8: 8
Case #9: 9
Case #10: 10
Case #11: 11
Case #12: 12
Case #13: 13
Case #14: 13
Case #15: 13
"),

};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void MagicalWellOfLiliesTest(IOHelper testCase)
		{
			RoundH.Program.MagicalWellOfLilies(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}