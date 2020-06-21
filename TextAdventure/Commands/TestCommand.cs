using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class TestCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			return "This is a test command!";
		}
	}
}