using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands{
	public class ExitGameCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			gameState.GameIsOver = true;
			return "Thanks for playing!";
		}
	}
}