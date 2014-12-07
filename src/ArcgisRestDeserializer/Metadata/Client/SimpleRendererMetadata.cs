using System.Runtime.Serialization;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client
{
    [DataContract]
    public class SimpleRendererMetadata
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("rotationExpression")]
        public string RotationExpression { get; set; }

        [JsonProperty("rotationType")]
        public SymbolRotationType RotationType { get; set; }

        [JsonProperty("symbol")]
        [JsonConverter(typeof(SymbolConverter))]
        public Symbol Symbol { get; set; }
    }
}