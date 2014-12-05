using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Converters;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.Symbols.FillSymbol
    /// </summary>
    [DataContract]
    public class FillSymbolMetadata
    {
        // TODO

        [JsonProperty("outline.color")]
        [JsonConverter(typeof(ColorToBrushJsonConverter))]
        public Brush BorderBrush { get; set; }

        [JsonProperty("outline.width")]
        [JsonConverter(typeof(ComplexPathJsonConverter), "outline.width")]
        public double BorderThickness { get; set; }
        
        [DataMember(Name = "color")]
        [JsonConverter(typeof(ColorToBrushJsonConverter))]
        public Brush Fill { get; set; }
    }
}