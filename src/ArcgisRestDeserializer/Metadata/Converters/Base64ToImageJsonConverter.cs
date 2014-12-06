using System;
using System.Windows.Media;
using ArcgisRestDeserializer.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Special converter for creating BitmapImage from base64-string
    /// </summary>
    public class Base64ToImageJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(ImageSource));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<JValue>(reader);
            return obj.Value == null 
                ? null
                : Base64Decoder.Base64ToImage(obj.Value<string>());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}