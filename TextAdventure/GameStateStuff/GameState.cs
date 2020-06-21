namespace TextAdventure.GameStateStuff
{
	public class GameState
	{
		public Protagonist Protagonist { get; set; }
		public Location CurrentLocation { get; set; }
		public bool GameIsOver { get; set; }
	}
}