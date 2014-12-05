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
            resolver.RegisterTypeMetadata<MarkerSymbol, MarkerSymbolMetadata>();
            resolver.RegisterTypeMetadata<SimpleMarkerSymbol, SimpleMarkerSymbolMetadata>();
            return resolver;
        }
    }
}