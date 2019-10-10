using System;
using System.Runtime.Serialization;

namespace SimpleRpgGame
{
	[Serializable]
	class CannotMoveException : Exception
	{
		public CannotMoveException()
		{
		}
	}
}