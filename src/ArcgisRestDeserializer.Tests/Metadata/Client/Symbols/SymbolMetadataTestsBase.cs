using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Client.Symbols;
using ArcgisRestDeserializer.Tests.TestUtilities;
using ESRI.ArcGIS.Client.Symbols;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    public abstract class SymbolMetadataTestsBase : MetadataTestsBase
    {
        protected override DynamicMetadataContractResolver CreateResolver()
        {
            return base.CreateResolver()
                .RegisterTypeMetadata<MarkerSymbol, MarkerSymbolMetadata>()
                .RegisterTypeMetadata<SimpleMarkerSymbol, SimpleMarkerSymbolMetadata>()
                .RegisterTypeMetadata<LineSymbol, LineSymbolMetadata>()
                .RegisterTypeMetadata<SimpleLineSymbol, SimpleLineSymbolMetadata>()
                .RegisterTypeMetadata<FillSymbol, FillSymbolMetadata>()
                .RegisterTypeMetadata<SimpleFillSymbol, SimpleFillSymbolMetadata>()
                .RegisterTypeMetadata<PictureMarkerSymbol, PictureMarkerSymbolMetadata>()
                .RegisterTypeMetadata<PictureFillSymbol, PictureFillSymbolMetadata>();
        }
    }
}