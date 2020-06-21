using System.Collections.Generic;
using System.Linq;

namespace TextAdventure.GameStateStuff
{
	public class Protagonist
	{
		public IList<Item> Items { get; set; } = new List<Item>();
		public IList<Item> ItemsInspected { get; set; } = new List<Item>();
		public IList<Connection> ConnectionsInspected { get; set; } = new List<Connection>();
		public IList<Location> LocationsVisited { get; set; } = new List<Location>();
		public IList<string> ExtraCharacteristics { get; set; } = new List<string>();

		public IEnumerable<string> GetCharacteristics()
		{
			return this.Items.Select(i => $"owns-item {i.Name}")
					.Union(this.ItemsInspected.Select(ii => $"inspected-item {ii.Name}"))
					.Union(this.ConnectionsInspected.Select(ci => $"inspected-connection {ci.Name}"))
					.Union(this.LocationsVisited.Select(lv => $"visited-location {lv.Name}"))
					.Union(this.ExtraCharacteristics);
		}
	}
}