using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    [TestClass]
    public class PictureMarkerSymbolMetadataTests : SymbolMetadataTestsBase
    {
        [TestMethod]
        public void TestPictureMarkerSymbolMetadata()
        {
            // NOTE: simple example from http://resources.arcgis.com/en/help/arcgis-rest-api/index.html#/Symbol_Objects/02r3000000n5000000/
            const string data = @"{
  ""type"" : ""esriPMS"", 
  ""url"" : ""471E7E31"", 
  ""imageData"" : ""iVBORw0KGgoAAAANSUhEUgAAABoAAAAaCAYAAACpSkzOAAAAAXNSR0IB2cksfwAAAAlwSFlzAAAOxAAADsQBlSsOGwAAAMNJREFUSIntlcENwyAMRZ+lSMyQFcI8rJA50jWyQuahKzCDT+6h0EuL1BA1iip8Qg/Ex99fYuCkGv5bKK0EcB40YgSE7bnTxsa58LeOnMd0QhwGXkxB3L0w0IDxPaMqpBFxjLMuaSVmRjurWIcRDHxaiWZuEbRcEhpZpSNhE9O81GiMN5E0ZRt2M0iVjshek8UkTQfZy8JqGHYP/rJhODD4T6wehtbB9zD0MPQwlOphaAxD/uPLK7Z8MB5gFet+WKcJPQDx29XkRhqr/AAAAABJRU5ErkJggg=="", 
  ""contentType"" : ""image/png"", 
  ""width"" : 19.5, 
  ""height"" : 19.5, 
  ""angle"" : 0, 
  ""xoffset"" : 0, 
  ""yoffset"" : 0
}";
            var rez = JsonConvert.DeserializeObject<PictureMarkerSymbol>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.IsNotNull(rez.Source);
        }
    }
}