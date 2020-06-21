using System.Collections.Generic;

namespace TextAdventure.GameStateStuff
{
	public class OtherHardCodedExample
	{
		public static GameState Provide(){
			return new GameState{
				CurrentLevel = new Level
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
							Destination = new Level
							{
								ConditionalDescription = new ConditionalDescription(
									new List<KeyValuePair<string, string>>
									{
										new KeyValuePair<string, string>("always-true", "You win! Type \"exitgame\" to quit.")
									}
								)
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
		}
	}
}