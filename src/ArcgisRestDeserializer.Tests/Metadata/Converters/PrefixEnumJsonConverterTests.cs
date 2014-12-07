using System.Windows.Media;
using ArcgisRestDeserializer.Metadata.Converters;
using ArcgisRestDeserializer.Tests.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Converters
{
    [TestClass]
    public class PrefixEnumJsonConverterTests
    {
        [TestMethod]
        public void TestSimplePrefix()
        {
            string data = "{\"Value\":\"esriValue1\"}";
            var rez = JsonConvert.DeserializeObject<Item>(data, new PrefixEnumJsonConverter("esri"));
            Assert.AreEqual(rez.Value, TestEnum.Value1);

            data = "{\"Value\":\"esriValue2\"}";
            rez = JsonConvert.DeserializeObject<Item>(data, new PrefixEnumJsonConverter("esri"));
            Assert.AreEqual(rez.Value, TestEnum.Value2);
        }

        [TestMethod]
        public void TestNotIgnoreCase()
        {
            var data = "{\"Value\":\"esrivalue2\"}";
            var rez = JsonConvert.DeserializeObject<Item>(data, new PrefixEnumJsonConverter("esri"));
            Assert.AreEqual(rez.Value, TestEnum.Value2);

            data = "{\"Value\":\"esrivalue2\"}";
            ExceptionAssert.Throws<JsonSerializationException>(
                () => JsonConvert.DeserializeObject<Item>(data, new PrefixEnumJsonConverter("esri", false)));
        }

        #region | Nested Classes |

        public enum TestEnum
        {
            Value1,
            Value2
        }

        public class Item
        {
            //[JsonConverter(typeof(PrefixEnumJsonConverter), "esri")]
            public TestEnum Value { get; set; }
        }

        #endregion
    }
}