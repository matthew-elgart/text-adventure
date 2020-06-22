using System;
using Newtonsoft.Json;

namespace TextAdventure.GameStateStuff.Serialization
{
	public class DestinationConverter : JsonConverter
	{
		public override bool CanRead
		{
			get { return false; }
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Location);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var location = (Location) value;
			writer.WriteValue(location.Name);
		}
	}
}