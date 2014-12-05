using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    [TestClass]
    public class MarkerSymbolsMetadataTests : SymbolMetadataTestsBase
    {
        [TestMethod]
        public void TestMarkerSymbolMetadata()
        {
            const string data = @"{
""angle"" : 35,
""xoffset"" : 50,
""yoffset"" : 20,
}";
            var rez = JsonConvert.DeserializeObject<MarkerSymbol>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.Angle, 35);
            Assert.AreEqual(rez.OffsetX, 50);
            Assert.AreEqual(rez.OffsetY, 20);
        }
    }
}