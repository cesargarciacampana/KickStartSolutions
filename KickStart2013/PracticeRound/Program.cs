using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeRound
{
	class Program
	{
		static void Main(string[] args)
		{
			//Moist();
			//CaptainHammer();
			BadHorse();
		}

		private static int readInt()
		{
			return Convert.ToInt32(Console.ReadLine());
		}

		private static string readString()
		{
			return Console.ReadLine();
		}

		private static T[] readMultiple<T>(char separator = ' ')
		{
			return Console.ReadLine().Split(separator).Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray();
		}

		private static void print(int nCase, string value)
		{
			Console.WriteLine($"Case #{nCase}: {value}");
		}

		private static void print(int nCase, int value)
		{
			Console.WriteLine($"Case #{nCase}: {value}");
		}

		private static void print(int nCase, decimal value)
		{
			Console.WriteLine($"Case #{nCase}: {value.ToString("0.0000000", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))}");
		}

		private static void Moist()
		{
			int nTests = readInt();
			int[] costs = new int[nTests];
			for (int i = 0; i < nTests; i++)
			{
				int nPlayers = readInt();
				int cost = 0;
				string[] players = new string[nPlayers];
				for (int j = 0; j < nPlayers; j++)
				{
					players[j] = readString();
					bool moved = false;
					for(int k = j; k > 0; k--)
					{
						if (String.Compare(players[k-1],  players[k]) > 0)
						{
							string temp = players[k-1];
							players[k-1] = players[k];
							players[k] = temp;
							moved = true;
						}
					}
					if (moved)
						cost++;
				}
				costs[i] = cost;
			}

			for (int i = 0; i < nTests; i++)
				print(i + 1, costs[i]);
		}

		private static void CaptainHammer()
		{
			const decimal g = 9.8M;

			int nTests = readInt();
			decimal[] solutions = new decimal[nTests];
			for(int i = 0; i < nTests; i++)
			{
				int[] temp = readMultiple<int>();
				int V = temp[0];
				int D = temp[1];

				decimal tempResult = (D * g) / (V * V);
				double tempResult2 = Math.Asin((double)tempResult) / Math.PI;
				decimal tempResult3 = (180 / 2) * (decimal)tempResult2;
				if (tempResult3 < 0)
					tempResult3 += 360;

				solutions[i] = tempResult3;
			}
			for (int i = 0; i < nTests; i++)
				print(i + 1, solutions[i]);
		}

		private static void BadHorse()
		{
			int nTests = readInt();
			bool[] results = new bool[nTests];
			for (int i = 0; i < nTests; i++)
			{
				int nProblematic = readInt();

				Dictionary<string, HashSet<string>> problematics = new Dictionary<string, HashSet<string>>();

				for (int j = 0; j < nProblematic; j++)
				{
					string[] pair = readMultiple<String>();
					string name1 = pair[0];
					string name2 = pair[1];

					if (!problematics.ContainsKey(name1))
					{
						problematics[name1] = new HashSet<string>();
					}
					if (!problematics.ContainsKey(name2))
					{
						problematics[name2] = new HashSet<string>();
					}
					problematics[name1].Add(name2);
					problematics[name2].Add(name1);
				}

				List<string> group1 = new List<string>();
				List<string> group2 = new List<string>();

				string[] namesToTest = problematics.Keys.ToArray();
				results[i] = TestSolution(namesToTest, 0, group1, group2, problematics);
			}

			for (int i = 0; i < nTests; i++)
				print(i + 1, results[i] ? "Yes" : "No");
		}

		public static bool TestSolution(string[] namesToTest, int testIndexFrom, List<string> group1, List<string> group2, Dictionary<string, HashSet<string>> problematics)
		{
			if (group1.Count + group2.Count == problematics.Keys.Count)
				return true;

			string name = namesToTest[testIndexFrom];
			if (!group1.Any(x => problematics[x].Contains(name)))
			{
				group1.Add(name);

				if (TestSolution(namesToTest, testIndexFrom + 1, group1, group2, problematics))
					return true;

				group1.RemoveAt(group1.Count - 1);
			}

			if (!group2.Any(x => problematics[x].Contains(name)))
			{
				group2.Add(name);

				if (TestSolution(namesToTest, testIndexFrom + 1, group1, group2, problematics))
					return true;

				group2.RemoveAt(group2.Count - 1);
			}

			return false;
		}
	}
}
