using System;
using System.Linq;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class TakeItemCommand : ICommand
	{
		private readonly string _itemToTake;
		public TakeItemCommand(string itemToTake)
		{
			this._itemToTake = itemToTake;
		}
		public string ExecuteCommand(GameState gameState)
		{
			if (this._itemToTake == null)
			{
				return "You need to specify what to take.";
			}

			var currentLocation = gameState.CurrentLocation;
			var itemInLocation = currentLocation.Items
				.SingleOrDefault(i => i.Name.Equals(this._itemToTake, StringComparison.OrdinalIgnoreCase));
			if (itemInLocation == null) {
				return $"There is no [{this._itemToTake}] to take here.";
			}

			currentLocation.Items.Remove(itemInLocation);
			gameState.Protagonist.Items.Add(itemInLocation);
			return $"Took the [{itemInLocation.Name}].";
		}
	}
}