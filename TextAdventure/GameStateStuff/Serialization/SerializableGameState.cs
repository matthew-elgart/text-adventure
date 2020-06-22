using System.Collections.Generic;

namespace TextAdventure.GameStateStuff
{
	public class SerializableGameState
	{
		public IEnumerable<Location> Locations { get; set; }
		public string CurrentLocationName { get; set; }
		public Protagonist Protagonist { get; set; }
		public bool GameIsOver { get; set; }
	}
}