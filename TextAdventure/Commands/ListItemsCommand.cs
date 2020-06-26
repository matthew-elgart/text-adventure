using System.Linq;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class ListItemsCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			var protagonist = gameState.Protagonist;
			var items = protagonist.Items
				.Where(i => i.IsVisible(protagonist));
			if (!items.Any())
			{
				return "There's nothing in your inventory.";
			}

			var itemNames = items.Select(i => i.Name);
			return $"Inventory contents:\n{string.Join('\n', itemNames)}";
		}
	}
}