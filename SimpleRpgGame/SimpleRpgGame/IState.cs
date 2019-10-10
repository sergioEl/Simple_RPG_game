using System;
namespace SimpleRpgGame
{
	public interface IState
	{
		int Explore();
		int Battle(int level);
	}
}
