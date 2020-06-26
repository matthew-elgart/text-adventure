using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace TextAdventure.GameStateStuff
{
	public class ConditionalDescription : OrderedDictionary
	{
		[JsonConstructor]
		public ConditionalDescription(IDictionary descriptions)
		{
			foreach (var entry in descriptions)
			{
				var typedEntry = (DictionaryEntry)entry;
				this.Add((string)typedEntry.Key, (string)typedEntry.Value);
			}
		}

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
				if (TriggerChecker.CharacteristicsMatchTrigger(stringKey, protagonist.GetCharacteristics()))
				{
					return (string)this[key];
				}
			}
			return null;
		}
	}
}