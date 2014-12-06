using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.Symbols.FillSymbol
    /// </summary>
    [DataContract]
    public class FillSymbolMetadata
    {
        [JsonProperty("outline")]
        [PropertyDependency("Color", "BorderBrush")]
        [PropertyDependency("Width", "BorderThickness")]
        public SimpleLineSymbol Outline { get; set; }
        
        [DataMember(Name = "color")]
        [JsonConverter(typeof(ColorToBrushJsonConverter))]
        public Brush Fill { get; set; }
    }
}