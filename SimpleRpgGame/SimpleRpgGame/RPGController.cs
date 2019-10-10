namespace SimpleRpgGame
{
	public class RPGController
	{
		
		private IState exploreState;
		private IState battleState;
		private IState state;
		private int level = 1;

		public RPGController(Map map)
		{
			exploreState = new ExploreState(this,map);// c
			battleState = new BattleState(this);// c

			state = exploreState;
		}

		public IState getCurrentState()
		{
			return state;
		}

		public int Explore()
		{
			return state.Explore();
		}

		public int Battle()
		{
			return state.Battle(level);
		}

		public void SetState(IState state)
		{
			this.state = state;
		}

		public void SetLevel(int level)
		{
			this.level = level;
		}

		public int GetLevel()
		{
			return level;
		}

		public IState GetExploreState()
		{
			return exploreState;
		}

		public IState GetBattleState()
		{
			return battleState;
		}

	}
}