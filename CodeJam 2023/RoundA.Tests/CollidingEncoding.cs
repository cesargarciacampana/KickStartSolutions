namespace RoundA.Tests
{
	public class CollidingEncoding
	{
		[SetUp]
		public void Setup()
		{
		}

		static IOHelper[] testCases = new IOHelper[]
{
			new IOHelper(
 @"2
0 1 2 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
4
ABC
BC
BCD
CDE
0 1 2 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
3
CDE
DEF
EFG",
@"Case #1: NO
Case #2: YES
"),

			new IOHelper(
 @"2
0 1 2 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
4
ABCDEFGHIZ
JKLMNOPQR
STU
VWXYZ
0 1 2 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
3
A
A
A",
@"Case #1: NO
Case #2: YES
")

};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void CollidingEncodingTest(IOHelper testCase)
		{
			RoundA.Program.CollidingEncoding(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}