namespace TextAdventure.GameStateStuff.Serialization
{
	public class SerializableConnection
	{
		public string Name { get; set; }
		public ConditionalDescription ConditionalDescription { get; set; }
		public string Destination { get; set; }
		public string CharacteristicForEntry { get; set; }
	}
}