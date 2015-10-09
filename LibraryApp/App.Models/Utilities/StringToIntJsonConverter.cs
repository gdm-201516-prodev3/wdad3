using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Utilities
{
    /// <summary>
    /// Handles converting JSON string values into a C# Integer data type.
    /// </summary>
    public class StringToIntJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Nullable<int>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType == JsonToken.Integer)
                return reader.Value;

            if (reader.TokenType == JsonToken.String)
            {
                if (string.IsNullOrEmpty((string)reader.Value))
                    return null;
                int num;
                if (int.TryParse((string)reader.Value, out num))
                    return num;

                throw new JsonReaderException(string.Format("Expected integer, got {0}", reader.Value));
            }
            throw new JsonReaderException(string.Format("Unexcepted token {0}", reader.TokenType));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
