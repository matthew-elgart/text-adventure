using System.IO;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class SerializationHelpers
	{
		public const string SaveFileExtension = ".json";

		public static string GetSaveFileDirectory()
		{
			#if DEBUG
			var executableDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			#else
			var executableDirectory = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
			#endif
			return Path.Combine(executableDirectory, "SaveFiles");
		}
	}
}