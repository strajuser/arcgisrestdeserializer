using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.Symbols.MarkerSymbol
    /// </summary>
    [DataContract]
    public class MarkerSymbolMetadata
    {
        [JsonProperty("angle")]
        public double Angle { get; set; }

        [JsonProperty("xoffset")]
        public virtual double OffsetX { get; set; }
        [JsonProperty("yoffset")]
        public virtual double OffsetY { get; set; }
    }
}