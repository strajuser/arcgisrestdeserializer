using ESRI.ArcGIS.Client.Symbols;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Hierarhy converter for Line Symbols
    /// </summary>
    public class LineSymbolConverter : SymbolConverterBase<LineSymbol>
    {
        public override LineSymbol Create(string type)
        {
            switch (type)
            {
                case "esriSLS":
                    return new SimpleLineSymbol();
                default:
                    return null;
            }
        }
    }
}