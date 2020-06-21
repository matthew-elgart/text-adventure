using TextAdventure.Extensions;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class HelpCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			return @"
			Command List:
			""location"": repeat description of current location
			""inventory"": list out items in inventory
			""inspect"": see description of item in current location, or connection to another location
			""check"": check description of item in inventory
			""take"": take item from current location
			""enter"": enter new location using a connection from current location
			""exitgame"": quit current game
			".Unindent();
		}
	}
}