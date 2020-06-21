using System;
using TextAdventure.Commands;

namespace TextAdventure
{
	public class InputParser
	{
		// TODO: consider making these not static (not sure)
		public static ICommand ParseInput(string input)
		{
			if (!InputParser.InputIsValid(input))
			{
				throw new ArgumentException("Invalid command");
			}

			var splitInput = input.ToLower().Split(new[] { ' ' }, 2);
			var command = splitInput[0];
			var parameter = splitInput.Length == 2 ? splitInput[1] : null;

			switch (command)
			{
				case "location":
					return new LevelDescriptionCommand();
				case "inventory":
					return new ListItemsCommand();
				case "take":
					return new TakeItemCommand(parameter);
				case "inspect":
					return new InspectCommand(parameter);
				case "check":
					return new CheckCommand(parameter);
				case "enter":
					return new EnterCommand(parameter);
				case "help":
					return new HelpCommand();
				case "exitgame":
					return new ExitGameCommand();
				default:
					return new InvalidInputCommand();
			}
		}

		// TODO: implement
		public static bool InputIsValid(string input)
		{
			return true;
		}
	}
}