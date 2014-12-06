using System.Windows.Media;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Client.Symbols
{
    [TestClass]
    public class PictureFillSymbolMetadataTests : SymbolMetadataTestsBase
    {
        [TestMethod]
        public void TestPictureFillSymbolMetadata()
        {
            // NOTE: simple example from http://resources.arcgis.com/en/help/arcgis-rest-api/index.html#/Symbol_Objects/02r3000000n5000000/
            const string data = @"{
  ""type"" : ""esriPFS"", 
  ""url"" : ""866880A0"", 
  ""imageData"" : ""iVBORw0KGgoAAAANSUhEUgAAAFQAAABUCAYAAAAcaxDBAAAAAXNSR0IB2cksfwAAAAlwSFlzAAAOxAAADsQBlSsOGwAAAM9JREFUeJzt0EEJADAMwMA96l/zTBwUSk5ByLxQsx1wTUOxhmINxRqKNRRrKNZQrKFYQ7GGYg3FGoo1FGso1lCsoVhDsYZiDcUaijUUayjWUKyhWEOxhmINxRqKNRRrKNZQrKFYQ7GGYg3FGoo1FGso1lCsoVhDsYZiDcUaijUUayjWUKyhWEOxhmINxRqKNRRrKNZQrKFYQ7GGYg3FGoo1FGso1lCsoVhDsYZiDcUaijUUayjWUKyhWEOxhmINxRqKNRRrKNZQrKFYQ7GGYh/hIwFRFpnZNAAAAABJRU5ErkJggg=="", 
  ""contentType"" : ""image/png"", 
  ""outline"" : 
  {
    ""type"" : ""esriSLS"", 
    ""style"" : ""esriSLSSolid"", 
    ""color"" : [110,110,110,255], 
    ""width"" : 2
  }, 
  ""width"" : 63, 
  ""height"" : 63, 
  ""angle"" : 0, 
  ""xoffset"" : 0, 
  ""yoffset"" : 0, 
  ""xscale"" : 1, 
  ""yscale"" : 1
}";
            var rez = JsonConvert.DeserializeObject<PictureFillSymbol>(data, CreateSettings());
            Assert.IsNotNull(rez);

            var fill = rez.Fill as SolidColorBrush;
            Assert.IsNull(fill);

            Assert.IsNotNull(rez.Source);

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