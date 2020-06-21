namespace TextAdventure.GameStateStuff
{
	public class Item
	{
		public string Name { get; set; }
		public ConditionalDescription ConditionalDescription { get; set; }

		public string GetDescription(Protagonist protagonist)
		{
			return this.ConditionalDescription.GetDescription(protagonist);
		}
	}
}