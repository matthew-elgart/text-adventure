using System;
using TextAdventure.GameStateStuff;

namespace TextAdventure
{
	public class GamePlayer
	{
		private readonly GameState _gameState;
		public GamePlayer(GameState gameState)
		{
			this._gameState = gameState;
		}
		public void Play()
		{
			Console.WriteLine(this._gameState.CurrentLocation.GetFullLocationDescription(this._gameState.Protagonist));

			while (!this._gameState.GameIsOver)
			{
				var input = Program.ReadInputFromUser();
				var command = InputParser.ParseInput(input);
				var stringToPrint = command.ExecuteCommand(this._gameState);
				Console.WriteLine(stringToPrint);
			}
		}

		public static void WriteWrapped(string text){
			const int maxLineLength = 80;
			foreach (var line in GamePlayer.WordWrap(text, maxLineLength)){
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