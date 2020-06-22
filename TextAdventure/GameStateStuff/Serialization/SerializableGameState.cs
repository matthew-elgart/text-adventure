using System.Collections.Generic;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class SerializableGameState
	{
		public IEnumerable<SerializableLocation> Locations { get; set; }
		public string CurrentLocationName { get; set; }
		public Protagonist Protagonist { get; set; }
		public bool GameIsOver { get; set; }
	}
}