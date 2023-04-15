#define print

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoundA
{
	public class Program
	{
		static void Main(string[] args)
		{
			var console = new ConsoleIO();

			//CollidingEncoding(console);
			//IlluminationOptimization(console);
			//RainbowSort(console);
			//AsciiArt(console);
			Untie(console);
		}


		public static void Untie(ConsoleIO console)
		{
			int nTests = console.readInt();
			for (int i = 0; i < nTests; i++)
			{
				string temp = console.ReadLine();

				int minimum = MinChangesToUntie(temp.ToArray(), temp.ToArray(), 0, 0);



//				if (IsTied(game))
//				{
//					minimum = Int32.MaxValue;
//					char[] possiblePlays = GetOtherPlays(game[0]);
//					foreach (char possiblePlay in possiblePlays)
//					{
//						minimum = Math.Min(minimum, MinChangesToUntie(game, 1, 0, possiblePlay));
//#if print
//						Console.WriteLine($"Intento ({minimum}):" + String.Join(null, game));
//#endif
//					}
//				}
//				else
//					minimum = 0;

				console.print(i + 1, minimum);
			}
		}

		private static int MinChangesToUntie(char[] originalGame, char[] currentGame, int currentChanges, int position)
		{
			if (position == currentGame.Length)
			{
				if (IsTied(currentGame))
					return Int32.MaxValue;
				else
					return 0;
			}

			int minimum = Int32.MaxValue;

			if (IsTied(currentGame))
			{
				foreach (char possiblePlay in PossiblePlays)
				{
					currentGame[position] = possiblePlay;

					int change = (currentGame[position] == originalGame[position] ? 0 : 1);

					minimum = Math.Min(minimum, MinChangesToUntie(originalGame, currentGame, currentChanges + change, position + 1));
#if print
					if (minimum != Int32.MaxValue)
					{
						Console.WriteLine($"Intento ({currentChanges}/{minimum}/{change}/{position}):" + String.Join(null, currentGame));
					}
#endif
				}
			}
			else
				minimum = 0;

			currentGame[position] = originalGame[position];

			return minimum == Int32.MaxValue ? minimum : currentChanges + minimum;
		}

		static readonly char[] PossiblePlays = new char[] { 'P', 'S', 'R' };

		private static bool IsTied(char[] game)
		{
			if (game[0] == game[game.Length - 1])
				return true;

			for(int i = 0; i < game.Length - 1; i++)
			{
				if (game[i] == game[i + 1])
					return true;
			}

			return false;
		}

		public static void AsciiArt(ConsoleIO console)
		{
			int nTests = console.readInt();
			for (int i = 0; i < nTests; i++)
			{
				long position = console.readLong();

				long current = 26;
				int count = 1;

				while(position > current)
				{
					count++;
					position -= current;
					current += 26;
				}

				long letterPosition = (position - 1) / count;
				char letter = (char)('A' + (int)letterPosition);

				string result = letter.ToString();
				console.print(i + 1, result);
			}
		}

		public static void RainbowSort(ConsoleIO console)
		{
			int nTests = console.readInt();
			for (int i = 0; i < nTests; i++)
			{
				int nCards = console.readInt();
				int[] colors = console.readMultiple<int>();
				bool possible = true;
				var colorValues = new Dictionary<int, int>();

				int last = -1;
				for (int j = 0; j < colors.Length; j++)
				{
					var current = colors[j];
					if (colorValues.ContainsKey(current))
					{
						if (last != current)
						{
							possible = false;
							break;
						}
					}
					else
					{
						colorValues.Add(current, j);
						last = current;
					}
				}

				string result = !possible 
					? "IMPOSSIBLE" 
					: string.Join(' ', colorValues.OrderBy(x => x.Value).Select(x => x.Key));
				console.print(i + 1, result);
			}
		}

		public static void IlluminationOptimization(ConsoleIO console)
		{
			int nTests = console.readInt();
			for (int i = 0; i < nTests; i++)
			{
				int[] values = console.readMultiple<int>();
				int totalLength = values[0]; //M
				int illuminationRadius = values[1]; //R
				int nTotalLights = values[2]; //N

				int[] locations = console.readMultiple<int>();

				var lights = new List<Tuple<int, int>>();

				for(int j = 0; j < locations.Length; j++)
				{
					Tuple<int, int> current = GetMinMax(totalLength, locations[j], illuminationRadius);

					if (lights.Count == 1 && current.Item1 == 0)
						lights.RemoveAt(0);

					while (lights.Count > 1 && lights[lights.Count - 2].Item2 >= current.Item1)
						lights.RemoveAt(lights.Count - 1);

					if (lights.Count == 0)
					{
						if (current.Item1 > 0)
							break;
					}
					else
					{
						if (lights[lights.Count - 1].Item2 < current.Item1)
						{
							lights.Clear();
							break;
						}
					}

					if (lights.Count == 0 || lights[lights.Count - 1].Item2 < totalLength)
						lights.Add(current);
				}

				if (lights.Count > 0 && lights[lights.Count - 1].Item2 < totalLength)
					lights.Clear();

				string result = lights.Count == 0 ? "IMPOSSIBLE" : lights.Count.ToString();
				console.print(i + 1, result);
			}
		}

		private static Tuple<int, int> GetMinMax(int totalLength, int location, int radius)
		{
			return new Tuple<int, int>(Math.Max(0, location - radius), Math.Min(totalLength, location + radius));
		}

		public static void CollidingEncoding(ConsoleIO console)
		{
			int nTests = console.readInt();
			for (int i = 0; i < nTests; i++)
			{
				int[] mappingDigits = console.readMultiple<int>(); //Length = 26

				int nWords = console.readInt();
				bool collision = false;

				var usedWords = new HashSet<long>();

				for (int j = 0; j < nWords; j++)
				{
					string word = console.ReadLine();

					if (collision)
						continue;

					long mapped = Convert.ToInt64("1" +
							string.Join(null, word.Select(x => string.Empty + GetMappedDigit(mappingDigits, x))));

					if (usedWords.Contains(mapped))
					{
						collision = true;
					}

					usedWords.Add(mapped);
				}

				string result = collision ? "YES" : "NO";
				console.print(i + 1, result);
			}
		}

		private static int GetMappedDigit(int[] mappingDigits, char character)
		{
			int position = character - 'A';
			return mappingDigits?.Length > position
				? mappingDigits[position]
				: 0;
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

			public long readLong()
			{
				return Convert.ToInt64(ReadLine());
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