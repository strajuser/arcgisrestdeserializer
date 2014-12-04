using ESRI.ArcGIS.Client.Symbols;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Hierarhy converter for Fill Symbols
    /// </summary>
    public class FillSymbolConverter : SymbolConverterBase<FillSymbol>
    {
        public override FillSymbol Create(string type)
        {
            switch (type)
            {
                case "esriSFS":
                    return new SimpleFillSymbol();
                case "esriPFS":
                    return new PictureFillSymbol();
                default:
                    return null;
            }
        }
    }
}