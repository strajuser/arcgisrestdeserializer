using System;
using System.Windows.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Brush converter from byte arrays
    /// </summary>
    public class ColorToBrushJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Brush).IsAssignableFrom(objectType);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = serializer.Deserialize<JArray>(reader);
            if (array.Count > 4 || array.Count < 3)
                throw new JsonSerializationException("Incorrect array length: expected 3 or 4.");

            int start = array.Count == 4 ? 1 : 0;
            byte alpha = array.Count == 4 ? array[0].Value<byte>() : (byte)255;
            return new SolidColorBrush(Color.FromArgb(alpha, array[start].Value<byte>(),
                array[start + 1].Value<byte>(), array[start + 2].Value<byte>()));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}