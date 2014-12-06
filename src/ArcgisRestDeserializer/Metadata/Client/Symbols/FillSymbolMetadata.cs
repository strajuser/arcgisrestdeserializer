using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Metadata.Client.Symbols
{
    /// <summary>
    /// Metadata for class ESRI.ArcGIS.Client.Symbols.FillSymbol
    /// </summary>
    [DataContract]
    public class FillSymbolMetadata
    {
        [JsonProperty("outline")]
        [PropertyDependency("Color", "BorderBrush")]
        [PropertyDependency("Width", "BorderThickness")]
        public SimpleLineSymbol Outline { get; set; }

        /* TODO
         * [PropertyDependency<FillSymbol, SimpleLineSymbol>(
         *      x => x.BorderBrush,
         *      x => x.Color
         * )]
         */

        /*
         * [PropertyDependency<FillSymbol, JObject>(
         *      x => x.BorderThickness,
         *      x => x["width"].Value<int>()
         * )] 
         * public JObject Outline { get; set; }
         * 
         */

        [JsonProperty("color")]
        [JsonConverter(typeof(ColorToBrushJsonConverter))]
        public Brush Fill { get; set; }
    }
}