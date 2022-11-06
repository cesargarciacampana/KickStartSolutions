using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundA.Tests
{
	internal class PalindromeFreeStringTests
	{
		static IOHelper[] testCases = new IOHelper[]
		{
			new IOHelper(
 @"2
9
100???001
5
100??",
@"Case #1: IMPOSSIBLE
Case #2: POSSIBLE
"),

new IOHelper(
 @"2
9
?
5
?1?",
@"Case #1: POSSIBLE
Case #2: POSSIBLE
"),

			new IOHelper(
 @"4
9
111100101100101100101?
9
1111001011001?1100101?
5
111100101100101100101111?0000
5
1111?0000",
@"Case #1: POSSIBLE
Case #2: POSSIBLE
Case #3: IMPOSSIBLE
Case #4: IMPOSSIBLE
"),

new IOHelper(
 @"6
9
1000?1110
13
100110?100110
6
?0101?
5
?????
6
01111?
20
1000111",
@"Case #1: IMPOSSIBLE
Case #2: IMPOSSIBLE
Case #3: POSSIBLE
Case #4: POSSIBLE
Case #5: IMPOSSIBLE
Case #6: IMPOSSIBLE
"),

new IOHelper(
 @"5
4
????
5
?????
7
?11111?
5
1?0?1
5
10001",
@"Case #1: POSSIBLE
Case #2: POSSIBLE
Case #3: IMPOSSIBLE
Case #4: POSSIBLE
Case #5: IMPOSSIBLE
"),

		};

		[Test]
		[TestCaseSource(nameof(testCases))]
		public void PalindromeFreeStringTest(IOHelper testCase)
		{
			RoundA.Program.PalindromeFreeStrings(testCase);

			Assert.IsTrue(testCase.ExpectedOutput == testCase.Output.ToString());
		}

		[TestCase("10010", ExpectedResult = true)]
		[TestCase("00000", ExpectedResult = false)]
		[TestCase("1001001", ExpectedResult = false)]
		[TestCase("10011001", ExpectedResult = false)]
		[TestCase("01110", ExpectedResult = false)]
		[TestCase("0100011", ExpectedResult = false)]
		public bool IsPalinfromeFreeTest(string text)
		{
			return Program.IsPalindromeFree(text.ToCharArray(), text.Length - 1);
		}
	}
}
