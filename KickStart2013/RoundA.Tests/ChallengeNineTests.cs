using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundA.Tests
{
	internal class ChallengeNineTests
	{
		static IOHelper[] testCases = new IOHelper[]
		{
			new IOHelper(
 @"3
5
33
12121",
@"Case #1: 45
Case #2: 333
Case #3: 121212
"),

			new IOHelper(
 @"3
947
123
81",
@"Case #1: 7947
Case #2: 1233
Case #3: 801
"),
		};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void ChallengeNineTest(IOHelper testCase)
		{
			RoundA.Program.ChallengeNine(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}
	}
}
