using System.Runtime.Serialization;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.Symbols.MarkerSymbol
    /// </summary>
    [DataContract]
    public class MarkerSymbolMetadata
    {
        [DataMember(Name = "angle")]
        public double Angle { get; set; }

        [DataMember(Name = "xoffset")]
        public virtual double OffsetX { get; set; }
        [DataMember(Name = "yoffset")]
        public virtual double OffsetY { get; set; }
    }
}