using System;
using System.Linq;
using Newtonsoft.Json;
using TextAdventure.GameStateStuff.Serialization;

namespace TextAdventure.GameStateStuff
{
	public class Connection
	{
		public string Name { get; set; }
		public ConditionalDescription ConditionalDescription { get; set; }
		[JsonConverter(typeof(DestinationConverter))]
		public Location Destination { get; set; }
		public string CharacteristicForEntry { get; set; }

		public string GetDescription(Protagonist protagonist)
		{
			return this.ConditionalDescription.GetDescription(protagonist);
		}

		public bool IsEnterable(Protagonist protagonist){
			return protagonist.GetCharacteristics()
				.Any(c => string.Equals(c, this.CharacteristicForEntry, StringComparison.OrdinalIgnoreCase));
		}
	}
}