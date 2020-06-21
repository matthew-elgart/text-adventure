using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands{
	public class InvalidInputCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			return "Command not recognized.";
		}
	}
}