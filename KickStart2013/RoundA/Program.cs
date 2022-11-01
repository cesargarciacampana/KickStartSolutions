using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundA
{
	public class Program
	{
		static void Main(string[] args)
		{
            SpeedTyping(new ConsoleIO());
        }

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
                WriteLine($"Case #{nCase}: {value}");
            }

            public void print(int nCase, int value)
            {
                WriteLine($"Case #{nCase}: {value}");
            }
        }

    }
}
