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

			var currentLevel = gameState.CurrentLevel;
			var itemInLevel = currentLevel.Items
				.SingleOrDefault(i => i.Name.Equals(this._itemToTake, StringComparison.OrdinalIgnoreCase));
			if (itemInLevel == null) {
				return $"There is no [{this._itemToTake}] to take here.";
			}

			currentLevel.Items.Remove(itemInLevel);
			gameState.Protagonist.Items.Add(itemInLevel);
			return $"Took the [{itemInLevel.Name}].";
		}
	}
}