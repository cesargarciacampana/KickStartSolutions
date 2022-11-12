using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoundH
{
	public class Program
	{
		static void Main(string[] args)
		{
			var console = new ConsoleIO();

			//RunningInCircles(console);
			MagicalWellOfLilies(console);
		}

		public static void RunningInCircles(ConsoleIO console)
		{
			int nTests = console.readInt();
			for (int i = 0; i < nTests; i++)
			{
				long[] numbers = console.readMultiple<long>();
				var length = numbers[0];
				var laps = numbers[1];

				long count = 0;

				bool lastDirection = true;
				long acumulatedDistance = 0;

				for (int j = 0; j < laps; j++)
				{
					string[] lap = console.readMultiple<string>();

					long distance = Convert.ToInt64(lap[0]);
					bool clockwise = lap[1] == "C";

					if (clockwise != lastDirection)
					{
						count += acumulatedDistance / length;
						acumulatedDistance = acumulatedDistance % length - distance;
						if (acumulatedDistance <= 0)
						{
							lastDirection = clockwise;
							acumulatedDistance = -acumulatedDistance;
						}
					}
					else
						acumulatedDistance += distance;
				}

				count += acumulatedDistance / length;

				console.print(i + 1, count.ToString());
			}
		}

		public static void MagicalWellOfLilies(ConsoleIO console)
		{
			int nTests = console.readInt();
			for (int i = 0; i < nTests; i++)
			{
				int nLilies = console.readInt();

				int min = MinCountLilies(0, 0, nLilies);

				console.print(i + 1, min);
			}
		}

		private static int MinCountLilies(int tossedOut, int noted, int nLiliesLeft)
		{
			if (nLiliesLeft <= 1)
				return nLiliesLeft;
			else if (nLiliesLeft == noted)
				return 2;
			else
			{
				int coinsUsed = 1;
				int min = MinCountLilies(tossedOut + 1, noted, nLiliesLeft - 1);
				if (noted < tossedOut && tossedOut <= nLiliesLeft && 6 < min + coinsUsed)
				{
					int min2 = MinCountLilies(tossedOut, tossedOut, nLiliesLeft);
					if (min2 + 4 < min + coinsUsed)
					{
						coinsUsed = 4;
						min = min2;
					}
				}

				if (noted > 0 && noted <= nLiliesLeft && 2 < min + coinsUsed)
				{
					int min3 = MinCountLilies(tossedOut + noted, noted, nLiliesLeft - noted);
					if (min3 + 2 < min + coinsUsed)
					{
						coinsUsed = 2;
						min = min3;
					}
				}

				return coinsUsed + min;
			}
		}

		//public static void Base(ConsoleIO console)
		//{
		//	int nTests = console.readInt();
		//	for (int i = 0; i < nTests; i++)
		//	{

		//	}
		//}

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

			public T[] readMultiple<T>(char separator = ' ')
			{
				return ReadLine().Split(separator).Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray();
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