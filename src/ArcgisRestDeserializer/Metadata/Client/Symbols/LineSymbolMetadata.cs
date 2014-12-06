using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Metadata.Converters;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.Symbols.LineSymbol
    /// </summary>
    [DataContract]
    public class LineSymbolMetadata
    {
        [JsonProperty("color")]
        [JsonConverter(typeof(ColorToBrushJsonConverter))]
        public Brush Color { get; set; }

        [DataMember(Name = "width")]
        public double Width { get; set; } 
    }
}