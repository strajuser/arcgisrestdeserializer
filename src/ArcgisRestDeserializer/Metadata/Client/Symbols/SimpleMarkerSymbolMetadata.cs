using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for ESRI.ArcGIS.Client.Symbols.SimpleMarkerSymbol
    /// </summary>
    [DataContract]
    public class SimpleMarkerSymbolMetadata : MarkerSymbolMetadata
    {
        [DataMember(Name = "color")]
        [JsonConverter(typeof(ColorToBrushJsonConverter))]
        public Brush Color { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "style")]
        [JsonConverter(typeof(PrefixEnumJsonConverter), "esriSMS")]
        public SimpleMarkerSymbol.SimpleMarkerStyle Style { get; set; }

        // NOTE: This properties should ignored because they have no setters in ESRI.ArcGIS.Client.Symbols.SimpleMarkerSymbol

        [JsonIgnore]
        public override double OffsetX { get; set; }
        [JsonIgnore]
        public override double OffsetY { get; set; }
    }
}