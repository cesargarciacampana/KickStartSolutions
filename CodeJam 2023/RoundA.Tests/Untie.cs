namespace RoundA.Tests
{
	public class Untie
	{
		[SetUp]
		public void Setup()
		{
		}

		static IOHelper[] testCases = new IOHelper[]
{
			new IOHelper(
 @"3
PRSSP
RRRRRRR
RSPRPSPRS",
@"Case #1: 2
Case #2: 4
Case #3: 0
"),

						new IOHelper(
 @"1
PPP",
@"Case #1: 2
")

};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void UntieTest(IOHelper testCase)
		{
			RoundA.Program.Untie(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}