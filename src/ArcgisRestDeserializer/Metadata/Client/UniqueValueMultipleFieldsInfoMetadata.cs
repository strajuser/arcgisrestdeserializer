using System.Runtime.Serialization;
using ArcgisRestDeserializer.Infrastructure;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client
{
    /// <summary>
    /// Metadata for ESRI.ArcGIS.Client.UniqueValueMultipleFieldsInfo
    /// </summary>
    [DataContract]
    public class UniqueValueMultipleFieldsInfoMetadata : RendererInfoMetadata
    {
        [JsonProperty("value")]
        [JsonConverter(typeof(StringSplitToArrayJsonConverter), ",")]
        public object[] Values { get; set; }
    }
}