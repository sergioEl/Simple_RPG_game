using System;
namespace SimpleRpgGame
{
	public class Map
	{
		RPGController rpgMap;//c

		public int[,] map;
		public int[,] mapForMonster;

		static Random rnd = new Random();

		public static int PLAYER = 1;
		public static int ENEMY = 2;
		public static int PATH = 3;

		int rowOfMap = rnd.Next(4,10);
		int columnOfMap = rnd.Next(4,10);
		int enemyNumbers = rnd.Next(4,10);

		int playerRowPoint = 0;
		int playerColumnPoint = 0;

		int playerFomalRowPotin = 0;//c
		int playerFomalColPoint = 0;//c


		public int getCurrentPosition()
		{
			try
			{
				return mapForMonster[playerRowPoint, playerColumnPoint];

			}
			catch (IndexOutOfRangeException )
			{
				Console.WriteLine("Out of map");
				return 0;
			}
		}

		public void makeRpg(RPGController r)
		{
			rpgMap = r;
		}


		public Map() // Constructor 
		{
			if (rowOfMap > 0 && columnOfMap > 0 && enemyNumbers > 0)
			{

				//rpgMap = rpg;//c

				map = new int[rowOfMap, columnOfMap];
				mapForMonster = new int[rowOfMap, columnOfMap];//for detect monster

				map[playerRowPoint, playerColumnPoint] = PLAYER;
				for (int i = 0; i < enemyNumbers; i++)
				{
					int enemyRowRan = rnd.Next(1, rowOfMap);// c
					int enemyColRan = rnd.Next(1, columnOfMap);// c

					// Add line for location of enemys 
					map[enemyRowRan, enemyColRan] = ENEMY;
				}
				for (int j = 0; j < rowOfMap; j++)
				{
					for (int k = 0; k < columnOfMap; k++)
					{
						if (!(map[j, k] == PLAYER || map[j, k] == ENEMY))
						{
							map[j, k] = PATH;
						}
					}
				}
				Array.Copy(map, 0, mapForMonster, 0, map.Length);//copy Array
			}
		}

		public void move()
		{

				Console.WriteLine("enter way that you want to move(e,w,s,n) ");
				ConsoleKeyInfo key;
				key = Console.ReadKey();

				Console.WriteLine();

				try
				{
					if (!((key.Key == ConsoleKey.E) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.S) || (key.Key == ConsoleKey.N)))
					{
						throw new IncorrectValueException();
					}

					if (rpgMap.getCurrentState() == rpgMap.GetBattleState()) // c
					{
						throw new CannotMoveException();
					} // if end
				}

				catch (IncorrectValueException ex)
				{
					Console.WriteLine("try again!!!");
					key = Console.ReadKey();
				}
				catch (CannotMoveException ex)
				{
				Console.WriteLine("You can't move there is a monster! Only A(attack)\n");
					key = Console.ReadKey();
				}

				try
				{
					switch (key.Key)
					{
						case ConsoleKey.E:
							playerFomalColPoint = playerColumnPoint;//c
							playerFomalRowPotin = playerRowPoint;//c
							map[playerRowPoint, playerColumnPoint] = PATH;
							playerColumnPoint++;
							map[playerRowPoint, playerColumnPoint] = PLAYER;
							break;
						case ConsoleKey.W:
							playerFomalColPoint = playerColumnPoint;//c
							playerFomalRowPotin = playerRowPoint;//c
							map[playerRowPoint, playerColumnPoint] = PATH;
							playerColumnPoint--;
							map[playerRowPoint, playerColumnPoint] = PLAYER;
							break;
						case ConsoleKey.S:
							playerFomalColPoint = playerColumnPoint;//c
							playerFomalRowPotin = playerRowPoint;//c
							map[playerRowPoint, playerColumnPoint] = PATH;
							playerRowPoint++;
							map[playerRowPoint, playerColumnPoint] = PLAYER;
							break;
						case ConsoleKey.N:
							playerFomalColPoint = playerColumnPoint;//c
							playerFomalRowPotin = playerRowPoint;//c
							map[playerRowPoint, playerColumnPoint] = PATH;
							playerRowPoint--;
							map[playerRowPoint, playerColumnPoint] = PLAYER;
							break;
						default:
							break;
					}

				}
				catch (IndexOutOfRangeException ex)
				{
					Console.WriteLine("You are out of map try again!!!");
					playerRowPoint = playerFomalRowPotin;//c
				playerColumnPoint = playerFomalColPoint;//c
			}

		}

		public void printMap()
		{
			Console.WriteLine(toString());
		}

		public string toString()
		{
			string result = "";
			for (int i = 0; i < rowOfMap; i++)
			{
				for (int j = 0; j < columnOfMap; j++)
				{
					if (map[i, j] == PLAYER)
					{
						result += "  *  ";
					}
					else if(map[i, j] == PATH)
					{
						result += " =-= ";
					}
					else
					{
						result += " ^.^ ";
					}
				}
				result += "\n";
			}
			return result;
		}

	}
}