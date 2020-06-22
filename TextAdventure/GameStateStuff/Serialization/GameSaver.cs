using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class GameSaver
	{
		public const string SaveFileExtension = ".json";

		public static bool SaveGameState(GameState gameState, string fileName)
		{
			var allLocations = GameSaver.TraverseAllLocations(gameState.CurrentLocation);
			var sortedLocations = allLocations.OrderBy(l => l.Name);
			var serializableGameState = new SerializableGameState
			{
				Locations = sortedLocations,
				CurrentLocationName = gameState.CurrentLocation.Name,
				Protagonist = gameState.Protagonist,
				GameIsOver = gameState.GameIsOver
			};
			var jsonString = JsonConvert.SerializeObject(serializableGameState);

			var saveFileDirectory = GameSaver.GetSaveFileDirectory();
			Directory.CreateDirectory(saveFileDirectory);

			var saveFilePath = Path.Combine(saveFileDirectory, $"{fileName}{GameSaver.SaveFileExtension}");
			var fileExists = File.Exists(saveFilePath);

			File.WriteAllText(saveFilePath, jsonString);
			return fileExists;
		}

		public static string GetSaveFileDirectory()
		{
			var executableDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			return Path.Combine(executableDirectory, "SaveFiles");
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