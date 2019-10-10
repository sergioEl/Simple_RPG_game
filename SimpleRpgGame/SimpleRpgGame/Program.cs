using System;

namespace SimpleRpgGame
{
	class MainClass
	{
		
		static Map map = new Map();
		static RPGController rpg = new RPGController(map);

		static int score = 0;
		static int nextLevel = 10;

		public static void Main(string[] args)
		{
			map.makeRpg(rpg);//avoid error

			ConsoleKeyInfo key;

			Console.WriteLine("-=-=-= Seokho's Battle Adventure v1.0 -=-=-=");

			do
			{
				map.printMap();
				Console.WriteLine();
				Console.WriteLine("L = look around, A = Attack, Q = Quit");
				Console.WriteLine("Score[{0}] Level[{1}] Action[L,A,Q]: ", score, rpg.GetLevel());

				key = Console.ReadKey();

				Console.WriteLine();

				DoAction(key.Key);

			} while (key.Key != ConsoleKey.Q && rpg.GetLevel() < 10);

			if (rpg.GetLevel() >= 10)
			{
				Console.WriteLine();
				Console.WriteLine("You win! final score is {0}", score);
			}

			Console.ReadKey();

		}


		static void DoAction(ConsoleKey key)
		{
			if (key == ConsoleKey.L)
			{
				map.move();
				int points = rpg.Explore();
				if (points > 0)
				{
					Console.WriteLine("You gain {0} heroic points!",points);
					score += points;
				}
			}
			else if (key == ConsoleKey.A)
			{
				int rounds = rpg.Battle();
				if (rounds > 0)
				{
					int points = 10 - rounds;
					if (points < 0)
					{
						points = 0;
					}

					score += points;

					Console.WriteLine("You gain {0} heroic points!", points);
				}
			}

			if (score >= nextLevel)
			{
				rpg.SetLevel(rpg.GetLevel() + 1);
				nextLevel = rpg.GetLevel() * 10;

				Console.WriteLine("Your wonderous experience has gained you a level! level " + rpg.GetLevel());
			}

		}// end DoAction()

	}

	public static class RandomGenerator
	{
		private static Random random = new Random();

		public static int GetRandomNumber(int maxValue)
		{
			return random.Next(maxValue);
		}
	}
}
