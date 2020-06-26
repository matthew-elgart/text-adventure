using System;
using System.Linq;

namespace TextAdventure.GameStateStuff
{
	public class Connection
	{
		public string Name { get; set; }
		public ConditionalDescription ConditionalDescription { get; set; }
		public Location Destination { get; set; }
		public string CharacteristicForVisibility { get; set; } = null;
		public string CharacteristicForEntry { get; set; } = null;

		public string GetDescription(Protagonist protagonist)
		{
			return this.ConditionalDescription.GetDescription(protagonist);
		}

		public bool IsVisible(Protagonist protagonist)
		{
			return TriggerChecker.CharacteristicsMatchTrigger(this.CharacteristicForVisibility,
				protagonist.GetCharacteristics());
		}

		public bool IsEnterable(Protagonist protagonist)
		{
			return this.IsVisible(protagonist) 
				&& TriggerChecker.CharacteristicsMatchTrigger(this.CharacteristicForEntry,
					protagonist.GetCharacteristics());
		}
	}
}