using System.Linq;
using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class LevelDescriptionCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			return gameState.CurrentLevel.GetFullLevelDescription(gameState.Protagonist);
		}
	}
}