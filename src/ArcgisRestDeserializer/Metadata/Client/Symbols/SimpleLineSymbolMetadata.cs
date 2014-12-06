using System.Runtime.Serialization;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for ESRI.ArcGIS.Client.Symbols.SimpleLineSymbol
    /// </summary>
    [DataContract]
    public class SimpleLineSymbolMetadata : LineSymbolMetadata
    {
        [JsonProperty("style")]
        [JsonConverter(typeof(PrefixEnumJsonConverter), "esriSLS")]
        public SimpleLineSymbol.LineStyle Style { get; set; }
    }
}