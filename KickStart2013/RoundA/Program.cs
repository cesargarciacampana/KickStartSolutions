using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundA
{
	public class Program
	{
		static void Main(string[] args)
		{
			//SpeedTyping(new ConsoleIO());
			ChallengeNine(new ConsoleIO());
		}

		/// <summary>
		/// https://codingcompetitions.withgoogle.com/kickstart/round/00000000008cb33e/00000000009e7021
		/// </summary>
		/// <param name="console"></param>
		public static void SpeedTyping(ConsoleIO console)
		{
			int nTests = console.readInt();
			int[] costs = new int[nTests];
			for (int i = 0; i < nTests; i++)
			{
				string desired = console.ReadLine();
				string typed = console.ReadLine();

				bool possible = true;
				int nRemoved = 0;

				int ip = 0;
				for(int ii = 0; ii < desired.Length; ii++)
				{
					int temp = ip;
					ip = typed.IndexOf(desired[ii], ip);
					
					if (ip == -1)
					{
						possible = false;
						break;
					}

					nRemoved += ip - temp;
					ip++;
				}

				nRemoved += typed.Length - ip;

				if (possible)
					console.print(i + 1, nRemoved);
				else
                    console.print(i + 1, "IMPOSSIBLE");
			}
		}

		private static int CharToInt(char c) => c - '0';

		/// <summary>
		/// https://codingcompetitions.withgoogle.com/kickstart/round/00000000008cb33e/00000000009e7997
		/// </summary>
		/// <param name="console"></param>
		public static void ChallengeNine(ConsoleIO console)
		{
			int nTests = console.readInt();

			for (int i = 0; i < nTests; i++)
			{
				string number = console.ReadLine();
				int sumDigits = number.Sum(x => CharToInt(x));
				int needed = (9 - sumDigits % 9) % 9;
				string result = "";

				if (needed == 0)
				{
					result = number.Insert(1, "0");
				}
				else
				{
					bool added = false;
					int j = 0;
					while(j < number.Length)
					{
						char c = number[j];
						if (CharToInt(c) > needed)
						{
							result += needed;
							added = true;
							break;
						}
						result += c;
						j++;
					}

					if (!added)
						result += needed;

					if (j < number.Length)
						result += number.Substring(j);
				}

				console.print(i + 1, result);
			}
		}

        public class ConsoleIO
        {
            public virtual string ReadLine()
            {
                return Console.ReadLine();
            }

            public virtual void WriteLine(string text)
            {
                Console.WriteLine(text);
            }
            public int readInt()
            {
                return Convert.ToInt32(ReadLine());
            }

            public void print(int nCase, string value)
            {
				if (nCase == 0)
					throw new Exception("nCase can't be zero");

                WriteLine($"Case #{nCase}: {value}");
            }

            public void print(int nCase, int value)
            {
				if (nCase == 0)
					throw new Exception("nCase can't be zero");

				WriteLine($"Case #{nCase}: {value}");
            }
        }

    }
}
