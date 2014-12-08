using System.Runtime.Serialization;
using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client
{
    /// <summary>
    /// Metadata for ESRI.ArcGIS.Client.UniqueValueMultipleFieldsRenderer
    /// </summary>
    [DataContract]
    public class UniqueValueMultipleFieldsRendererMetadata
    {
        [JsonProperty("defaultLabel")]
        public string DefaultLabel { get; set; }

        [JsonProperty("defaultSymbol")]
        [JsonConverter(typeof(SymbolConverter))]
        public Symbol DefaultSymbol { get; set; }

        [JsonProperty("fieldDelimiter")]
        public string FieldDelimiter { get; set; }

        [JsonProperty("field1")]
        [CollectionPropertyDependency("Fields")]
        public string Field1 { get; set; }

        [JsonProperty("field2")]
        [CollectionPropertyDependency("Fields")]
        public string Field2 { get; set; }

        [JsonProperty("field3")]
        [CollectionPropertyDependency("Fields")]
        public string Field3 { get; set; }

        [JsonProperty("uniqueValueInfos")]
        [CollectionPropertyDependency("Infos")]
        public UniqueValueMultipleFieldsInfo[] Infos { get; set; }

        [JsonProperty("rotationExpression")]
        public string RotationExpression { get; set; }

        [JsonProperty("rotationType")]
        public SymbolRotationType RotationType { get; set; }
    }
}