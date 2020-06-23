using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class GameSaver
	{
		public static bool SaveGameState(GameState gameState, string fileName)
		{
			var serializableGameState = GameSaver.GetSerializableGameState(gameState);
			var jsonString = JsonConvert.SerializeObject(serializableGameState, Formatting.Indented);

			var saveFileDirectory = SerializationHelpers.GetSaveFileDirectory();
			Directory.CreateDirectory(saveFileDirectory);

			var saveFilePath = Path.Combine(saveFileDirectory, $"{fileName}{SerializationHelpers.SaveFileExtension}");
			var fileExists = File.Exists(saveFilePath);

			File.WriteAllText(saveFilePath, jsonString);
			return fileExists;
		}

		private static SerializableGameState GetSerializableGameState(GameState gameState){
			var allLocations = GameSaver.TraverseAllLocations(gameState.CurrentLocation);
			var serializableLocations = allLocations
				.Select(l => new SerializableLocation
				{
					Name = l.Name,
					ConditionalDescription = l.ConditionalDescription,
					Items = l.Items,
					Connections = l.Connections.Select(c => new SerializableConnection
					{
						Name = c.Name,
						ConditionalDescription = c.ConditionalDescription,
						Destination = c.Destination.Name,
						CharacteristicForEntry = c.CharacteristicForEntry
					}).ToList()
				});

			return new SerializableGameState
			{
				Locations = serializableLocations.OrderBy(l => l.Name),
				CurrentLocationName = gameState.CurrentLocation.Name,
				Protagonist = gameState.Protagonist,
				GameIsOver = gameState.GameIsOver
			};
		}

		private static IEnumerable<Location> TraverseAllLocations(Location currentLocation)
		{
			var visitedLocations = new HashSet<Location>();
			var stack = new Stack<Location>();
			stack.Push(currentLocation);

			while (stack.Any())
			{
				var curr = stack.Pop();
				visitedLocations.Add(curr);
				var adjacentLocationsNotVisited = curr.Connections
					.Select(c => c.Destination)
					.Where(c => !visitedLocations.Contains(c));
				foreach (var destination in adjacentLocationsNotVisited)
				{
					stack.Push(destination);
				}
			}

			return visitedLocations;
		}
	}
}