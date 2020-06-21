using System.Linq;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class ListItemsCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			var items = gameState.Protagonist.Items;
			if (!items.Any())
			{
				return "There's nothing in your inventory.";
			}

			var itemNames = gameState.Protagonist.Items.Select(i => i.Name);
			return $"Inventory contents:\n{string.Join('\n', itemNames)}";
		}
	}
}