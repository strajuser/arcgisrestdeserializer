using ESRI.ArcGIS.Client.Symbols;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Hierarhy converter for all types of symbols
    /// </summary>
    public class SymbolConverter : SymbolConverterBase<Symbol>
    {
        private readonly MarkerSymbolConverter _markerSymbolConverter = new MarkerSymbolConverter();
        private readonly LineSymbolConverter _lineSymbolConverter = new LineSymbolConverter();
        private readonly FillSymbolConverter _fillSymbolConverter = new FillSymbolConverter();

        public override Symbol Create(string type)
        {
            switch (type)
            {
                case "esriTS":
                    return new TextSymbol();
                default:
                    return (Symbol)_markerSymbolConverter.Create(type)
                        ?? (Symbol)_lineSymbolConverter.Create(type)
                        ?? (Symbol)_fillSymbolConverter.Create(type);
            }
        }
    }
}