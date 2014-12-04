using System.Runtime.Serialization;
using ArcgisRestDeserializer.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Infrastructure
{
    [TestClass]
    public class DynamicMetadataContractResolverTests
    {
        [TestMethod]
        public void TestSimpleContractResolve()
        {
            const string data = "{\"name\":\"Test Item\", \"value\":5}";

            var resolver = new DynamicMetadataContractResolver();
            resolver.RegisterTypeMetadata<Item, ItemMetadata>();
            var item = JsonConvert.DeserializeObject<Item>(data, new JsonSerializerSettings
            {
                ContractResolver = resolver
            });

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Name, "Test Item");
            Assert.AreEqual(item.Value, 5);
        }

        #region | Nested Item Classes |

        public class Item
        {
            public string Name { get; set; }

            public int Value { get; set; }
        }

        [DataContract]
        public class ItemMetadata
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "value")]
            public int Value { get; set; }
        }

        #endregion
    }
}