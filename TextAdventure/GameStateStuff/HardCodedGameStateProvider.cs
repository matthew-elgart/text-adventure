using System.Collections.Generic;
using System.Linq;

namespace TextAdventure.GameStateStuff
{
	public class HardCodedGameStateProvider
	{
		public static GameState Provide()
		{
			var gameState = new GameState
			{
				CurrentLocation = new Location
				{
					Items = new List<Item>
					{
						new Item
						{
							Name = "Old Key",
							ConditionalDescription = new ConditionalDescription(
								new List<KeyValuePair<string, string>>
								{
									new KeyValuePair<string, string>("owns-item Old Key", "An old, rusty key you found lying on the mantlepiece. It looks like it could fit into the locked door."),
									new KeyValuePair<string, string>("always-true", "An old, rusty key lying on the mantlepiece. It looks like it could fit into the locked door.")
								}
							)
						}
					},
					Connections = new List<Connection>
					{
						new Connection
						{
							Name = "Heavy Door",
							ConditionalDescription = new ConditionalDescription(
								new List<KeyValuePair<string, string>>
								{
									new KeyValuePair<string, string>("owns-item Old Key", "A large, heavy iron door. The key you found on the mantlepiece seems to fit its keyhole."),
									new KeyValuePair<string, string>("always-true", "A large, heavy iron door. It's shut and won't budge.")
								}
							),
							Destination = new Location
							{
								ConditionalDescription = new ConditionalDescription(
									new List<KeyValuePair<string, string>>
									{
										new KeyValuePair<string, string>("always-true", "You win! Type \"exitgame\" to quit.")
									}
								),
								Connections = new List<Connection>
								{
									new Connection
									{
										Name = "Easy-to-open Door",
										ConditionalDescription = new ConditionalDescription(
											new List<KeyValuePair<string, string>>
											{
												new KeyValuePair<string, string>("always-true", "It looks easy to open.")
											}
										),
										CharacteristicForEntry = "always-true"
									}
								}
							},
							CharacteristicForEntry = "owns-item Old Key"
						}
					},
					ConditionalDescription = new ConditionalDescription(
						new List<KeyValuePair<string, string>>
						{
							new KeyValuePair<string, string>("always-true", "You are in an old, beaten-up room. Doesn't seem like there's much to do here, but there is a door on the far side of the room.")
						}
					)
				},
				Protagonist = new Protagonist
				{
					ExtraCharacteristics = new List<string> { "always-true" }
				}
			};
			//gameState.CurrentLocation.Connections.First().Destination.Connections.First().Destination = gameState.CurrentLocation;
			return gameState;
		}
	}
}