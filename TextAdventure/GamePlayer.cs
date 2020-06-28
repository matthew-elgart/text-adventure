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
	}
}