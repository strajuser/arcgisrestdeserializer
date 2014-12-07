using ArcgisRestDeserializer.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Tests.TestUtilities
{
    public abstract class MetadataTestBase
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