using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public interface ICommand
	{
		public string ExecuteCommand(GameState gameState);
	}
}