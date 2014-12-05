using System.Windows.Media;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    [TestClass]
    public class SimpleMarkerSymbolMetadataTests : SymbolMetadataTestsBase
    {
        [TestMethod]
        public void TestMarkerSymbolMetadata()
        {
            // NOTE: simple example from http://resources.arcgis.com/en/help/arcgis-rest-api/index.html#/Symbol_Objects/02r3000000n5000000/
            const string data = @"{
""type"": ""esriSMS"",
 ""style"": ""esriSMSSquare"",
 ""color"": [76,115,0,255],
 ""size"": 8,
 ""angle"": 0,
 ""xoffset"": 0,
 ""yoffset"": 0,
 ""outline"": 
  {
  ""color"": [152,230,0,255],
   ""width"": 1
  }
}";
            var rez = JsonConvert.DeserializeObject<SimpleMarkerSymbol>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.Angle, 0);
            // This properties are ignored
            //Assert.AreEqual(rez.OffsetX, 0);
            //Assert.AreEqual(rez.OffsetY, 0);
            Assert.AreEqual(rez.Size, 8);
            Assert.AreEqual(rez.Style, SimpleMarkerSymbol.SimpleMarkerStyle.Square);
            var brush = rez.Color as SolidColorBrush;
            Assert.IsTrue(brush != null);
            Assert.AreEqual(brush.Color.A, 76);
            Assert.AreEqual(brush.Color.R, 115);
            Assert.AreEqual(brush.Color.G, 0);
            Assert.AreEqual(brush.Color.B, 255);
        }
    }
}