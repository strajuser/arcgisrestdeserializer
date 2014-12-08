using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// JsonConverter for splitting strings to array
    /// </summary>
    public class StringSplitToArrayJsonConverter : JsonConverter
    {
        /// <summary>
        /// Gets or sets delimiter for String.Split
        /// </summary>
        public string Delimiter { get; set; }

        public StringSplitToArrayJsonConverter(string delimiter)
        {
            Delimiter = delimiter;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsArray;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<JValue>(reader);
            if (obj.Value == null)
                return null;

            return obj.Value<string>().Split(new[] {Delimiter}, StringSplitOptions.RemoveEmptyEntries).Select(x => (object) x).ToArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}