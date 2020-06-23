using System.Collections.Generic;
using System.Linq;

namespace TextAdventure.GameStateStuff
{
	public class Location
	{
		public string Name { get; set; }
		public ConditionalDescription ConditionalDescription { get; set; }
		public IList<Item> Items { get; set; } = new List<Item>();
		public IList<Connection> Connections { get; set; } = new List<Connection>();

		public string GetFullLocationDescription(Protagonist protagonist)
		{
			var levelDescription = this.GetDescription(protagonist);
			var itemNames = this.Items.Select(i => $"There is a [{i.Name}] here.");
			var connectionNames = this.Connections.Select(c => $"There is a [{c.Name}] here.");

			var result = levelDescription;

			if (itemNames.Any())
			{
				result += $"\n\n{string.Join('\n', itemNames)}";
			}
			if (connectionNames.Any())
			{
				result += $"\n\n{string.Join('\n', connectionNames)}";
			}

			return result;
		}
		
		public string GetDescription(Protagonist protagonist)
		{
			return this.ConditionalDescription.GetDescription(protagonist);
		}
	}
}