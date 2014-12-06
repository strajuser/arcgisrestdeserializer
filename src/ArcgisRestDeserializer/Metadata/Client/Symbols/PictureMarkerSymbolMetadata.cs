using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Metadata.Converters;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.Symbols.PictureMarkerSymbol
    /// </summary>
    [DataContract]
    public class PictureMarkerSymbolMetadata : MarkerSymbolMetadata
    {
        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        // TODO: add support for ImageSource from url

        [JsonProperty("imageData")]
        [JsonConverter(typeof(Base64ToImageJsonConverter))]
        public ImageSource Source { get; set; }
    }
}