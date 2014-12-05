using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// JsonConverter to 
    /// </summary>
    public class ComplexPathJsonConverter : JsonConverter
    {
        /// <summary>
        /// Gets or sets complex path for conveter
        /// </summary>
        public string ComplexPath { get; set; }

        public ComplexPathJsonConverter(string complexPath)
        {
            ComplexPath = complexPath;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<JObject>(reader);
            var pathes = ComplexPath.Split('.');
            return obj[pathes[1]];
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}