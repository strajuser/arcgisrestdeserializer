using System.Runtime.Serialization;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client
{
    /// <summary>
    /// Metadata for ESRI.ArcGIS.Client.UniqueValueRenderer
    /// </summary>
    [DataContract]
    public class UniqueValueRendererMetadata
    {
        [JsonProperty("defaultLabel")]
        public string DefaultLabel { get; set; }

        [JsonProperty("defaultSymbol")]
        [JsonConverter(typeof(SymbolConverter))]
        public Symbol DefaultSymbol { get; set; }

        [JsonProperty("field1")]
        public string Field { get; set; }
        
        // TODO:
        // public ObservableCollection<UniqueValueInfo> Infos { get; }

        [JsonProperty("rotationExpression")]
        public string RotationExpression { get; set; }

        [JsonProperty("rotationType")]
        public SymbolRotationType RotationType { get; set; }
    }
}