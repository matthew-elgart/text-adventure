using System;
using System.Linq;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class InspectCommand : ICommand
	{
		private readonly string _objectToInspect;

		public InspectCommand(string objectToInspect)
		{
			this._objectToInspect = objectToInspect;
		}

		public string ExecuteCommand(GameState gameState)
		{
			if (this._objectToInspect == null)
			{
				return "You need to specify what to inspect.";
			}

			var currentLocation = gameState.CurrentLocation;
			var item = currentLocation.Items
				.SingleOrDefault(i => i.Name.Equals(this._objectToInspect, StringComparison.OrdinalIgnoreCase));
			if (item != null)
			{
				return item.GetDescription(gameState.Protagonist);
			}

			var connection = currentLocation.Connections
				.SingleOrDefault(c => c.Name.Equals(this._objectToInspect, StringComparison.OrdinalIgnoreCase));
			if (connection != null)
			{
				return connection.GetDescription(gameState.Protagonist);
			}

			return $"There is no [{this._objectToInspect}] here to inspect.";
		}
	}
}