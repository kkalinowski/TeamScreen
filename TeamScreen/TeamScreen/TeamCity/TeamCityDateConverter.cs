using System;
using System.Globalization;
using Newtonsoft.Json;

namespace TeamScreen.TeamCity
{
    public class TeamCityDateConverter : JsonConverter
    {
        private static readonly string[] Iso8601DateTimeFormats = { 
            // Basic formats
            "yyyyMMddTHHmmsszzz",
            "yyyyMMddTHHmmsszz",
            "yyyyMMddTHHmmssZ",
            // Extended formats
            "yyyy-MM-ddTHH:mm:sszzz",
            "yyyy-MM-ddTHH:mm:sszz",
            "yyyy-MM-ddTHH:mm:ssZ",
            // All of the above with reduced accuracy
            "yyyyMMddTHHmmzzz",
            "yyyyMMddTHHmmzz",
            "yyyyMMddTHHmmZ",
            "yyyy-MM-ddTHH:mmzzz",
            "yyyy-MM-ddTHH:mmzz",
            "yyyy-MM-ddTHH:mmZ",
            // Accuracy reduced to hours
            "yyyyMMddTHHzzz",
            "yyyyMMddTHHzz",
            "yyyyMMddTHHZ",
            "yyyy-MM-ddTHHzzz",
            "yyyy-MM-ddTHHzz",
            "yyyy-MM-ddTHHZ"
        };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var text = reader.Value.ToString();
            if (string.IsNullOrEmpty(text))
                return null;
            else
                return DateTime.ParseExact(text, Iso8601DateTimeFormats,
                    CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }
    }
}