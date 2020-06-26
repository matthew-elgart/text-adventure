namespace TextAdventure.GameStateStuff
{
	public class Item
	{
		public string Name { get; set; }
		public ConditionalDescription ConditionalDescription { get; set; }
		public string CharacteristicForVisibility { get; set; } = null;
		public string CharacteristicForTaking { get; set; } = null;

		public string GetDescription(Protagonist protagonist)
		{
			return this.ConditionalDescription.GetDescription(protagonist);
		}

		public bool IsVisible(Protagonist protagonist)
		{
			return TriggerChecker.CharacteristicsMatchTrigger(this.CharacteristicForVisibility,
				protagonist.GetCharacteristics());
		}

		public bool IsTakeable(Protagonist protagonist)
		{
			return this.IsVisible(protagonist)
				&& TriggerChecker.CharacteristicsMatchTrigger(this.CharacteristicForTaking,
					protagonist.GetCharacteristics());
		}
	}
}