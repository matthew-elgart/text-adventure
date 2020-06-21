using System.Collections.Generic;

namespace TextAdventure.GameStateStuff
{
	public class HardCodedGameStateProvider
	{
		public static GameState Provide()
		{
			return null;
			//return new GameState
			//{
			//	CurrentLevel = new Level
			//	{
			//		Name = "Room1",
			//		Description = "This is a room.",
			//		Items = new List<Item>
			//		{
			//			new Item
			//			{
			//				Name = "Old Key",
			//				Description = "This key is very old."
			//			},
			//			new Item
			//			{
			//				Name = "New Key",
			//				Description = "This key is pretty new."
			//			}
			//		},
			//		Connections = new List<Connection>
			//		{
			//			new Connection
			//			{
			//				Name = "Heavy Door",
			//				Description = "A heavy-looking door.",
			//				Destination = new Level
			//				{
			//					Name = "Room2",
			//					Description = "You made it through the door!",
			//					Items = new List<Item>(),
			//					Connections = new List<Connection>()
			//				}
			//			}
			//		}
			//	},

			//	Protagonist = new Protagonist
			//	{
			//		Items = new List<Item> {
			//			new Item
			//			{
			//				Name = "Old Balloon", Description = "This balloon is very old."
			//			},
			//			new Item
			//			{
			//				Name = "New Balloon", Description = "This balloon is pretty new."
			//			}
			//		}
			//	}
			//};
		}
	}
}