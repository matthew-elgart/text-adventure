using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAdventure.GameStateStuff
{
	public static class TriggerChecker
	{
		public static bool CharacteristicsMatchTrigger(string triggerString, IEnumerable<string> characteristics)
		{
			// if the trigger is null (e.g. if it wasn't set), default to true
			if (triggerString == null)
			{
				return true;
			}

			const string negateFlag = "not ";
			const string delimeter = " and ";
			var splitTriggers = Regex.Split(triggerString, delimeter, RegexOptions.IgnoreCase);
			var parsedTriggers = splitTriggers.Select(st => TriggerChecker.CreateTrigger(st, negateFlag));

			return parsedTriggers.All(pt => pt.ShouldBeNegated
				? !characteristics.Contains(pt.TriggerText)
				: characteristics.Contains(pt.TriggerText));
		}

		private static Trigger CreateTrigger(string triggerString, string negateFlag)
		{
			if (triggerString.StartsWith(negateFlag, StringComparison.CurrentCultureIgnoreCase))
			{
				return new Trigger
				{
					TriggerText = triggerString.Remove(0, negateFlag.Length),
					ShouldBeNegated = true
				};
			}
			return new Trigger
			{
				TriggerText = triggerString,
				ShouldBeNegated = false
			};
		}

		private class Trigger
		{
			public string TriggerText { get; set; }
			public bool ShouldBeNegated { get; set; }
		}
	}
}