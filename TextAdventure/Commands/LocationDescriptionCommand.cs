using TextAdventure.GameStateStuff;

namespace TextAdventure.Commands
{
	public class LocationDescriptionCommand : ICommand
	{
		public string ExecuteCommand(GameState gameState)
		{
			return gameState.CurrentLocation.GetFullLocationDescription(gameState.Protagonist);
		}
	}
}