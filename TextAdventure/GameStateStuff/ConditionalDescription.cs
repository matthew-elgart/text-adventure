using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace TextAdventure.GameStateStuff
{
	public class ConditionalDescription : OrderedDictionary
	{
		public ConditionalDescription(IEnumerable<KeyValuePair<string, string>> descriptions)
		{
			foreach (var pair in descriptions)
			{
				this.Add(pair.Key, pair.Value);
			}
		}

		public string GetDescription(Protagonist protagonist)
		{
			foreach (var key in this.Keys)
			{
				var stringKey = (string)key;
				if (protagonist.GetCharacteristics().Any(c => string.Equals(c, stringKey, StringComparison.OrdinalIgnoreCase)))
				{
					return (string)this[key];
				}
			}
			return null;
		}
	}
}