using System.Windows.Media;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    [TestClass]
    public class SimpleFillSymbolMetadataTests : SymbolMetadataTestsBase
    {
        [TestMethod]
        public void TestSimpleLineSymbolMetadata()
        {
            // NOTE: simple example from http://resources.arcgis.com/en/help/arcgis-rest-api/index.html#/Symbol_Objects/02r3000000n5000000/
            const string data = @"{
  ""type"": ""esriSFS"",
  ""style"": ""esriSFSSolid"",
  ""color"": [115,76,0,255],
    ""outline"": {
     ""type"": ""esriSLS"",
     ""style"": ""esriSLSSolid"",
     ""color"": [110,110,110,255],
     ""width"": 2
	 }
}";
            var rez = JsonConvert.DeserializeObject<SimpleFillSymbol>(data, CreateSettings());
            Assert.IsNotNull(rez);

            var fill = rez.Fill as SolidColorBrush;
            Assert.IsNotNull(fill);
            Assert.AreEqual(fill.Color.A, 115);
            Assert.AreEqual(fill.Color.R, 76);
            Assert.AreEqual(fill.Color.G, 0);
            Assert.AreEqual(fill.Color.B, 255);

            Assert.AreEqual(rez.BorderThickness, 2);
            var borderBrush = rez.BorderBrush as SolidColorBrush;
            Assert.IsNotNull(borderBrush);
            Assert.AreEqual(borderBrush.Color.A, 110);
            Assert.AreEqual(borderBrush.Color.R, 110);
            Assert.AreEqual(borderBrush.Color.G, 110);
            Assert.AreEqual(borderBrush.Color.B, 255);
        }
    }
}