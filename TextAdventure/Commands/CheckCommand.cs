
using System;
using System.Linq;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class CheckCommand : ICommand
	{
		private readonly string _itemToCheck;

		public CheckCommand(string itemToCheck)
		{
			this._itemToCheck = itemToCheck;
		}

		public string ExecuteCommand(GameState gameState)
		{
			if (this._itemToCheck == null)
			{
				return "You need to specify what to check.";
			}

			var protagonist = gameState.Protagonist;
			var item = protagonist.Items
				.SingleOrDefault(i => i.IsVisible(protagonist)
					&& i.Name.Equals(this._itemToCheck, StringComparison.OrdinalIgnoreCase));
			if (item != null){
				return item.GetDescription(gameState.Protagonist);
			}

			return $"There is no [{this._itemToCheck}] in your inventory to check.";
		}
	}
}