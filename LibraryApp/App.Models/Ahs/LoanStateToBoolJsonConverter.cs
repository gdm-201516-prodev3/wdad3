using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Ahs
{
    /// <summary>
    /// Handles converting Loanstate JSON string values into a C# boolean data type.
    /// </summary>
    public class LoanStateToBoolJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<Nullable<bool>>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Nullable<bool> loanStateFree = null;
            if (string.IsNullOrEmpty((string)value))
            {
                loanStateFree = null;
            }                
            else if (value.ToString().ToLower().Trim().Contains("aanwezig"))
            {
                loanStateFree = true;
            }
            else
            {
                loanStateFree = false;
            }

            serializer.Serialize(writer, loanStateFree);
        }
    }
}
