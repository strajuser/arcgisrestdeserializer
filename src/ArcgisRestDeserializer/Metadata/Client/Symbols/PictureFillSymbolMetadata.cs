using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Metadata.Converters;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    [DataContract]
    public class PictureFillSymbolMetadata : FillSymbolMetadata
    {
        // TODO: add support for ImageSource from url

        [JsonProperty("imageData")]
        [JsonConverter(typeof(Base64ToImageJsonConverter))]
        public ImageSource Source { get; set; }
    }
}