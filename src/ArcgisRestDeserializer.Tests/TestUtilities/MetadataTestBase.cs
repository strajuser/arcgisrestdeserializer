using ArcgisRestDeserializer.Infrastructure;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.TestUtilities
{
    public abstract class MetadataTestsBase
    {
        protected virtual JsonSerializerSettings CreateSettings(params JsonConverter[] converters)
        {
            return new JsonSerializerSettings
            {
                Converters = converters,
                ContractResolver = CreateResolver()
            };
        }

        protected virtual DynamicMetadataContractResolver CreateResolver()
        {
            return new DynamicMetadataContractResolver();
        }
    }
}