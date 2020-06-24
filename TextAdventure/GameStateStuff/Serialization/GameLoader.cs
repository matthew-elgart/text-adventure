using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class GameLoader
	{
		public static GameState LoadGameState(string saveFileName)
		{
			var saveFileDirectory = SerializationHelpers.GetSaveFileDirectory();
			var saveFilePath = Path.Combine(saveFileDirectory, $"{saveFileName}{SerializationHelpers.SaveFileExtension}");
			var jsonString = File.ReadAllText(saveFilePath);
			var serializedGameState = JsonConvert.DeserializeObject<SerializableGameState>(jsonString);
			return GameLoader.GetGameState(serializedGameState);
		}

		private static GameState GetGameState(SerializableGameState serializedGameState)
		{
			var allLocations = new List<Location>();
			var connectionsToDestinations = new Dictionary<Connection, string>();

			// First pass: create locations/connections with destinations set to null.
			// Make note of which connection will map to which destination in the dictionary.
			foreach (var serializableLocation in serializedGameState.Locations)
			{
				var location = new Location
				{
					Name = serializableLocation.Name,
					ConditionalDescription = serializableLocation.ConditionalDescription,
					Items = serializableLocation.Items,
					Connections = new List<Connection>()
				};

				foreach (var serializableConnection in serializableLocation.Connections)
				{
					var connection = new Connection
					{
						Name = serializableConnection.Name,
						ConditionalDescription = serializableConnection.ConditionalDescription,
						Destination = null,
						CharacteristicForEntry = serializableConnection.CharacteristicForEntry
					};

					location.Connections.Add(connection);
					connectionsToDestinations.Add(connection, serializableConnection.Destination);
				}

				allLocations.Add(location);
			}

			// Second pass: now that all locations have been created, set connection destinations
			// to the relevant Location objects
			var namesToLocations = allLocations.ToDictionary(l => l.Name);
			foreach (var location in allLocations)
			{
				foreach (var connection in location.Connections)
				{
					connection.Destination = namesToLocations[connectionsToDestinations[connection]];
				}
			}

			return new GameState
			{
				Protagonist = serializedGameState.Protagonist,
				CurrentLocation = namesToLocations[serializedGameState.CurrentLocationName],
				GameIsOver = serializedGameState.GameIsOver
			};
		}

		public static IEnumerable<string> GetAllSaveFiles()
		{
			var saveDirectory = SerializationHelpers.GetSaveFileDirectory();
			
			return Directory.EnumerateFiles(saveDirectory)
				.Where(f => string.Equals(Path.GetExtension(f),
					SerializationHelpers.SaveFileExtension,
					StringComparison.OrdinalIgnoreCase))
				.Select(f => Path.GetFileNameWithoutExtension(f));
		}
	}
}