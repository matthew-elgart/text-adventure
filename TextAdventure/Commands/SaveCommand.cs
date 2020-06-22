using System.IO;
using TextAdventure.GameStateStuff;
using TextAdventure.GameStateStuff.Serialization;

namespace TextAdventure.Commands
{
	public class SaveCommand : ICommand
	{
		private readonly string _saveFileName;

		public SaveCommand(string _saveFileName)
		{
			this._saveFileName = _saveFileName;
		}

		public string ExecuteCommand(GameState gameState)
		{
			if (this._saveFileName == null)
			{
				return "Provide a name for the save file.";
			}

			var filePath = Path.Combine(GameSaver.GetSaveFileDirectory(),
							   $"{this._saveFileName}{GameSaver.SaveFileExtension}");
			var fileWasOverwritten = GameSaver.SaveGameState(gameState, this._saveFileName);

			return $"Game saved to {filePath}{(fileWasOverwritten ? " (existing file was overwritten)" : "")}";
		}
	}
}