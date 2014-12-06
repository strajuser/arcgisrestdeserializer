using System.Windows.Media;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    [TestClass]
    public class LineSymbolMetadataTests : SymbolMetadataTestsBase
    {
        [TestMethod]
        public void TestSimpleLineSymbolMetadata()
        {
            // NOTE: simple example from http://resources.arcgis.com/en/help/arcgis-rest-api/index.html#/Symbol_Objects/02r3000000n5000000/
            const string data = @"{
""type"": ""esriSLS"",
""style"": ""esriSLSDot"",
""color"": [115,76,0,255],
""width"": 1
}";
            var rez = JsonConvert.DeserializeObject<SimpleLineSymbol>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.Width, 1);
            Assert.AreEqual(rez.Style, SimpleLineSymbol.LineStyle.Dot);
            var brush = rez.Color as SolidColorBrush;
            Assert.IsNotNull(brush);
            Assert.AreEqual(brush.Color.A, 115);
            Assert.AreEqual(brush.Color.R, 76);
            Assert.AreEqual(brush.Color.G, 0);
            Assert.AreEqual(brush.Color.B, 255);
        }
    }
}