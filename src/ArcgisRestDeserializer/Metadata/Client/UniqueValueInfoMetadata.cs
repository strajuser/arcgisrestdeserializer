using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client
{
    /// <summary>
    /// Metadata for ESRI.ArcGIS.Client.UniqueValueInfo
    /// </summary>
    [DataContract]
    public class UniqueValueInfoMetadata : RendererInfoMetadata
    {
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}