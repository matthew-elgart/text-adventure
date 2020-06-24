using System;
using System.Collections.Generic;
using System.Linq;
using TextAdventure.GameStateStuff;
using TextAdventure.GameStateStuff.Serialization;

namespace TextAdventure
{
	class Program
	{
		/*
		TODO Feature list:
		* "look" command
		* "examine" command
		* have a better way of mapping input to commands? (don't think so)
		* level edges
			* update "look" command
		* make "exitgame" a command"
		* "go" command
		* "help" command
		* revisit triggers (and characteristics?)
			* anything with a description gets it replaced with an ordered map and a method: GetDescription(Protagonist p)
			* protagonist also tracks locations been and objects inspected
			* protagonist has GetCharacteristics() method (name tbd) that combines all into enumerable of strings
			* connections being enterable
		* change level to location
		* reduce nesting on conditional/possible descriptions
		* implement saving
			* custom converter for destination of connection
			* saver
				* graph traversal to get all the locations
				* order the locations (by name? ID?)
				* write the string to a file
			* implement save command
				* investigate y/n confirmation on commands
		* loading
			* make serializable locations, connections
			* update transformation from gamestate to serializable gamestate
			* use those to have saver serialize those directly with no custom converters
			* implement transformation from serialized gamestate to regular gamestate
				* first pass, create locations with null destinations in connections
					* create dictionary of connection -> destinationName and name -> location
				* second pass, use dictionaries to populate destinations
			* load game state from file argument (or load command?)
				* get file from fileName
				* deserialize file contents
				* transform to gamestate
		- trigger updates
			- AND of multiple characteristics (OR can be done already with two triggers)
			- NOT of a characteristic
			- items being takeable
			- connections/items being visible
		- word wrapping update (some methods at the bottom of Program.cs)
		- tech debt:
			- make updates to things like ItemsInspected in relevant commands
			- extract stuff from Program.cs into a GamePlayer or something
			- improve UX when loading files/using directories that don't exist
		- considerations:
			- consider IDs instead of names
			- consider a more typesafe ordered dictionary: https://www.codeproject.com/Articles/18615/OrderedDictionary-T-A-generic-implementation-of-IO
			- Consider abstract class for thing with conditional description
			- "Can't take that" or "No X to take here"?
			- consider adding tests
		*/
		static void Main(string[] args)
		{
			const string clearScreen = "\u001b[2J" + "\u001b[H";
			Console.WriteLine(clearScreen);
			Console.WriteLine("Welcome to the game.");
			Console.WriteLine("Please enter the name of the game file you want to load, or enter \"list games\" to see all available files to load.");
			var fileName = Program.ReadInputFromUser();

			if (fileName == "list games")
			{
				var saveDirectory = SerializationHelpers.GetSaveFileDirectory();
				var allSaveFiles = GameLoader.GetAllSaveFiles();
				if (!allSaveFiles.Any())
				{
					Console.WriteLine($"No save games found in {saveDirectory}");
				}

				Console.WriteLine($"All available files in {saveDirectory}:");
				Console.WriteLine(string.Join('\n', allSaveFiles));
				Console.WriteLine();
				Console.WriteLine("Please enter the name of the game file you want to load.");
				fileName = Program.ReadInputFromUser();
			}

			GameState gameState = null;
			do
			{
				try
				{
					gameState = GameLoader.LoadGameState(fileName);
				}
				catch
				{
					Console.WriteLine($"Game \"{fileName}\" was not loaded successfully. Please try again with a different file.");
					fileName = Program.ReadInputFromUser();
				}
			} while (gameState == null);
			
			Console.WriteLine($"Game \"{fileName}\" loaded successfully. Type \"help\" for a list of available commands. Type \"exitgame\" to quit.");
			Console.WriteLine();
			Console.WriteLine("-----");
			Console.WriteLine();

			Console.WriteLine(gameState.CurrentLocation.GetFullLocationDescription(gameState.Protagonist));

			while (!gameState.GameIsOver)
			{
				var input = Program.ReadInputFromUser();
				var command = InputParser.ParseInput(input);
				var stringToPrint = command.ExecuteCommand(gameState);
				Console.WriteLine(stringToPrint);
			}
		}

		public static string ReadInputFromUser()
		{
			Console.WriteLine();
			Console.Write(">");
			var result = Console.ReadLine();
			Console.WriteLine();
			return result;
		}

		public static void WriteWrapped(string text){
			const int maxLineLength = 80;
			foreach (var line in Program.WordWrap(text, maxLineLength)){
				Console.WriteLine("{0, 62} {1, 80}", "", line);
			}
		}

		// Copied from https://gist.github.com/anderssonjohan/660952
		private static List<string> WordWrap(string text, int maxLineLength)
		{
			var list = new List<string>();

			int currentIndex;
			var lastWrap = 0;
			var whitespace = new[] { ' ', '\r', '\n', '\t' };
			do
			{
				currentIndex = lastWrap + maxLineLength > text.Length ? text.Length : (text.LastIndexOfAny(new[] { ' ', ',', '.', '?', '!', ':', ';', '-', '\n', '\r', '\t' }, Math.Min(text.Length - 1, lastWrap + maxLineLength)) + 1);
				if (currentIndex <= lastWrap)
					currentIndex = Math.Min(lastWrap + maxLineLength, text.Length);
				list.Add(text.Substring(lastWrap, currentIndex - lastWrap).Trim(whitespace));
				lastWrap = currentIndex;
			} while (currentIndex < text.Length);

			return list;
		}
	}
}
