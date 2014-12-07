using System.Runtime.Serialization;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.RendererInfo
    /// </summary>
    [DataContract]
    public class RendererInfoMetadata
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("symbol")]
        [JsonConverter(typeof(SymbolConverter))]
        public Symbol Symbol { get; set; } 
    }
}