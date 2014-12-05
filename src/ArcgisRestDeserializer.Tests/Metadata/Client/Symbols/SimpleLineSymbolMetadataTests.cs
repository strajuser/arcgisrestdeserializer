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
        public void TestLineSymbolMetadata()
        {
            const string data = @"{
""color"": [115,76,0,255],
""width"": 1
}";
            var rez = JsonConvert.DeserializeObject<LineSymbol>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.Width, 1);
            var brush = rez.Color as SolidColorBrush;
            Assert.IsNotNull(brush);
            Assert.AreEqual(brush.Color.A, 115);
            Assert.AreEqual(brush.Color.R, 76);
            Assert.AreEqual(brush.Color.G, 0);
            Assert.AreEqual(brush.Color.B, 255);
        }
    }
}