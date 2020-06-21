using System;
using TextAdventure.GameStateStuff;

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
		- revisit triggers (and characteristics?)
			* anything with a description gets it replaced with an ordered map and a method: GetDescription(Protagonist p)
			* protagonist also tracks locations been and objects inspected
			* protagonist has GetCharacteristics() method (name tbd) that combines all into enumerable of strings
			* connections being enterable
			- items being takeable
		- change level to location
		- "Can't take that" or "No X to take here"?
		- Consider abstract class for thing with conditional description
		- extract stuff from Program.cs into a GamePlayer or something
		- tests
		- loading
		- saving
		- consider a more typesafe ordered dictionary: https://www.codeproject.com/Articles/18615/OrderedDictionary-T-A-generic-implementation-of-IO
		*/
		static void Main(string[] args)
		{
			const string clearScreen = "\u001b[2J" + "\u001b[H";
			Console.WriteLine(clearScreen);
			Console.WriteLine("Welcome to the game. Type \"help\" for a list of available commands. Type \"exitgame\" to quit.");

			// TODO: read from file
			var gameState = HardCodedGameStateProvider.Provide();
			Console.WriteLine();
			Console.WriteLine(gameState.CurrentLocation.GetFullLocationDescription(gameState.Protagonist));

			while (!gameState.GameIsOver)
			{
				var input = Program.ReadInputFromUser();
				Console.WriteLine();

				var command = InputParser.ParseInput(input);
				var stringToPrint = command.ExecuteCommand(gameState);
				Console.WriteLine(stringToPrint);
			}
		}

		public static string ReadInputFromUser()
		{
			Console.WriteLine();
			Console.Write(">");
			return Console.ReadLine();
		}
	}
}
