using ESRI.ArcGIS.Client.Symbols;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Hierarhy converter for Marker Symbols
    /// </summary>
    public class MarkerSymbolConverter : SymbolConverterBase<MarkerSymbol>
    {
        public override MarkerSymbol Create(string type)
        {
            switch (type)
            {
                case "esriSMS":
                    return new SimpleMarkerSymbol();
                case "esriPMS":
                    return new PictureMarkerSymbol();
                default:
                    return null;
            }
        }
    }
}