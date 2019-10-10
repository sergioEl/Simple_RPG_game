using System;
namespace SimpleRpgGame
{
	public class BattleState : IState
	{
		private RPGController context;
		private int rounds = 0;

		public BattleState(RPGController context)
		{
			this.context = context;
		}

		public int Battle(int level)
		{
			Console.WriteLine("You try to slay the monster... ");

			rounds++;

			System.Threading.Thread.Sleep(1000);

			int maxRan = 10 - level;
			if (maxRan < 1)
			{
				maxRan = 1;
			}

			int ran = RandomGenerator.GetRandomNumber(maxRan);
			if (ran == 0)
			{
				Console.WriteLine("he's dead!");
				context.SetState(context.GetExploreState());

				int tempRounds = rounds;
				rounds = 0;

				return tempRounds;
			}
			else
			{
				Console.WriteLine("but fail..");
			}

			if (rounds >= 9)
			{
				Console.WriteLine("You panic and run away in fear");
				context.SetState(context.GetExploreState());

				rounds = 0;
			}
			return 0;

		}

		public int Explore()
		{
			Console.WriteLine("You'd love to, but see, there's this big ugly monster in front of you!");
			return 0;
		}
	}
}
