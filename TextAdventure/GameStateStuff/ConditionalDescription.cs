using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace TextAdventure.GameStateStuff
{
	public class ConditionalDescription
	{
		public OrderedDictionary PossibleDescriptions { get; set; }

		public ConditionalDescription(IEnumerable<KeyValuePair<string, string>> descriptions)
		{
			var dict = new OrderedDictionary();
			foreach (var pair in descriptions)
			{
				dict.Add(pair.Key, pair.Value);
			}
			this.PossibleDescriptions = dict;
		}

		public string GetDescription(Protagonist protagonist)
		{
			foreach (var key in this.PossibleDescriptions.Keys)
			{
				var stringKey = (string)key;
				if (protagonist.GetCharacteristics().Any(c => string.Equals(c, stringKey, StringComparison.OrdinalIgnoreCase)))
				{
					return (string)this.PossibleDescriptions[key];
				}
			}
			return null;
		}
	}
}