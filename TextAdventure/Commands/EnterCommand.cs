using System;
using System.Linq;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class EnterCommand : ICommand
	{
		private readonly string _connectionToEnter;
		public EnterCommand(string connectionToEnter)
		{
			this._connectionToEnter = connectionToEnter;
		}

		public string ExecuteCommand(GameState gameState)
		{
			if (this._connectionToEnter == null)
			{
				return "You need to specify where to go.";
			}

			var connection = gameState.CurrentLevel.Connections
				.SingleOrDefault(c => c.Name.Equals(this._connectionToEnter, StringComparison.OrdinalIgnoreCase));
			if (connection != null && connection.IsEnterable(gameState.Protagonist))
			{
				gameState.CurrentLevel = connection.Destination;
				return connection.Destination.GetFullLevelDescription(gameState.Protagonist);
			}

			return $"Can't go there.";
		}
	}
}