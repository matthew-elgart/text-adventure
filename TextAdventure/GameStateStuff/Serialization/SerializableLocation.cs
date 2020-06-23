using System.Collections.Generic;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class SerializableLocation
	{
		public string Name { get; set; }
		public ConditionalDescription ConditionalDescription { get; set; }
		public IList<Item> Items { get; set; }
		public IList<SerializableConnection> Connections { get; set; }
	}
}