using System.IO;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class SerializationHelpers
	{
		public const string SaveFileExtension = ".json";

		public static string GetSaveFileDirectory()
		{
			var executableDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			return Path.Combine(executableDirectory, "SaveFiles");
		}
	}
}