using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Convert strings with prefix to Enum (ex. esriSMSCircle -> SimpleMarkerSymbol.SimpleMarkerStyle.Circle)
    /// </summary>
    public class PrefixEnumJsonConverter : JsonConverter
    {
        /// <summary>
        /// Gets or sets additional prefix for enums
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets if converter should ignore case
        /// </summary>
        public bool IgnoreCase { get; set; }

        public PrefixEnumJsonConverter(string prefix = null, bool ignoreCase = false) : this(prefix)
        {
            IgnoreCase = ignoreCase;
        }

        public PrefixEnumJsonConverter(string prefix = null)
        {
            Prefix = prefix;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var prop = serializer.Deserialize<JValue>(reader);
            return Enum.Parse(objectType, prop.Value<string>().Replace(Prefix, ""), IgnoreCase);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}