namespace TextAdventure.GameStateStuff
{
	public class GameState
	{
		public Protagonist Protagonist { get; set; }
		public Level CurrentLevel { get; set; }
		public bool GameIsOver { get; set; }
	}
}