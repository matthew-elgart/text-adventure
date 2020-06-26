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
			var protagonist = gameState.Protagonist;
			var itemInLocation = currentLocation.Items
				.SingleOrDefault(i => i.IsTakeable(protagonist)
					&& i.Name.Equals(this._itemToTake, StringComparison.OrdinalIgnoreCase));
			if (itemInLocation == null) {
				return $"Can't take that.";
			}

			currentLocation.Items.Remove(itemInLocation);
			protagonist.Items.Add(itemInLocation);
			return $"[{itemInLocation.Name}] added to inventory.";
		}
	}
}