using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Client.Symbols;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    public abstract class SymbolMetadataTestsBase
    {
        protected JsonSerializerSettings CreateSettings(params JsonConverter[] converters)
        {
            return new JsonSerializerSettings
            {
                Converters = converters,
                ContractResolver = CreateResolver()
            };
        }

        protected virtual DefaultContractResolver CreateResolver()
        {
            var resolver = new DynamicMetadataContractResolver();
            resolver.RegisterTypeMetadata<MarkerSymbol, MarkerSymbolMetadata>()
                .RegisterTypeMetadata<SimpleMarkerSymbol, SimpleMarkerSymbolMetadata>()
                .RegisterTypeMetadata<LineSymbol, LineSymbolMetadata>()
                .RegisterTypeMetadata<SimpleLineSymbol, SimpleLineSymbolMetadata>()
                .RegisterTypeMetadata<FillSymbol, FillSymbolMetadata>()
                .RegisterTypeMetadata<SimpleFillSymbol, SimpleFillSymbolMetadata>()
                .RegisterTypeMetadata<PictureMarkerSymbol, PictureMarkerSymbolMetadata>()
                .RegisterTypeMetadata<PictureFillSymbol, PictureFillSymbolMetadata>();
            return resolver;
        }
    }
}