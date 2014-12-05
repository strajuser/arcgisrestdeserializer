using System.Runtime.Serialization;
using System.Windows.Media;
using ArcgisRestDeserializer.Metadata.Converters;
using ArcgisRestDeserializer.Tests.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Converters
{
    [TestClass]
    public class ColorToBrushJsonConverterTests
    {
        [TestMethod]
        public void TestFourColorConverting()
        {
            const string data = "{\"brush\" : [255,0,100,200] }";
            var test = JsonConvert.DeserializeObject(data);

            var rez = JsonConvert.DeserializeObject<Item>(data);
            var brush = rez.Brush as SolidColorBrush;
            Assert.IsNotNull(brush);
            Assert.IsTrue(brush.Color.A == 255);
            Assert.IsTrue(brush.Color.R == 0);
            Assert.IsTrue(brush.Color.G == 100);
            Assert.IsTrue(brush.Color.B == 200);
        }

        [TestMethod]
        public void TestThreeColorConverting()
        {
            const string data = "{\"brush\" : [0,100,200] }";
            var test = JsonConvert.DeserializeObject(data);

            var rez = JsonConvert.DeserializeObject<Item>(data);
            var brush = rez.Brush as SolidColorBrush;
            Assert.IsNotNull(brush);
            Assert.IsTrue(brush.Color.A == 255);
            Assert.IsTrue(brush.Color.R == 0);
            Assert.IsTrue(brush.Color.G == 100);
            Assert.IsTrue(brush.Color.B == 200);
        }

        [TestMethod]
        public void TestBadColorConverting()
        {
            string data = "{\"brush\" : [0,0] }";
            ExceptionAssert.Throws<JsonSerializationException>("Incorrect array length: expected 3 or 4.", () => JsonConvert.DeserializeObject<Item>(data));

            data = "{\"brush\" : [0,0,0,0,0] }";
            ExceptionAssert.Throws<JsonSerializationException>("Incorrect array length: expected 3 or 4.", () => JsonConvert.DeserializeObject<Item>(data));
        }

        #region | Nested Item Class |

        [DataContract]
        public class Item
        {
            [DataMember(Name = "brush")]
            [JsonConverter(typeof(ColorToBrushJsonConverter))]
            public Brush Brush { get; set; }
        }

        #endregion
    }
}