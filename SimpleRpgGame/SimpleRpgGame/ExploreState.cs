using System;
namespace SimpleRpgGame
{
	public class ExploreState : IState
	{
		Map newMap;
		private RPGController context;

		public ExploreState(RPGController context, Map map)
		{
			this.newMap = map;
			this.context = context;
		}

		public int Battle(int level)
		{
			Console.WriteLine("You find nothing to attack");
			return 0;
		}

		public int Explore()
		{
			Console.WriteLine("You are looking around for something to kill!!");

			int ran = RandomGenerator.GetRandomNumber(5);
			if (newMap.getCurrentPosition() == 2) //changed
				{
					Console.WriteLine("A monster!!! Prepare for battle!!");
					context.SetState(context.GetBattleState());
				}

			if (ran == 1)
			{
				Console.WriteLine("You find a golden jewel behind a tree!!");
				return 2;
			}

			return 0;
		}
	}
}
