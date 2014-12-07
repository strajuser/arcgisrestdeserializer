using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Client;
using ArcgisRestDeserializer.Metadata.Client.Symbols;
using ArcgisRestDeserializer.Tests.TestUtilities;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ArcgisRestDeserializer.Tests.Metadata.Client
{
    [TestClass]
    public class SimpleRendererMetadataTests : MetadataTestBase
    {
        [TestMethod]
        public void TestSimpleRendererMetadata()
        {
            const string data = @"{
   ""type"": ""simple"",
   ""symbol"": 
   {
    ""type"": ""esriSMS"",
    ""style"": ""esriSMSCircle"",
    ""color"": [255,0,0,255],
    ""size"": 5,
    ""angle"": 0,
    ""xoffset"": 0,
    ""yoffset"": 0,
    ""outline"": 
	{
     ""color"": [0,0,0,255],
     ""width"": 1
    }
   },
   ""label"": ""label"",
   ""description"": ""description"",
  ""rotationType"": ""geographic"",
  ""rotationExpression"": ""[Rotation] * 2""
}";
            var rez = JsonConvert.DeserializeObject<SimpleRenderer>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.Description, "description");
            Assert.AreEqual(rez.Label, "label");
            Assert.AreEqual(rez.RotationExpression, "[Rotation] * 2");

            var symbol = rez.Symbol as SimpleMarkerSymbol;
            Assert.IsNotNull(symbol);
            Assert.AreEqual(symbol.Style, SimpleMarkerSymbol.SimpleMarkerStyle.Circle);
            Assert.AreEqual(symbol.Size, 5);
        }

        protected override DynamicMetadataContractResolver CreateResolver()
        {
            return base.CreateResolver()
                .RegisterTypeMetadata<SimpleRenderer, SimpleRendererMetadata>()
                .RegisterTypeMetadata<SimpleMarkerSymbol, SimpleMarkerSymbolMetadata>();
        }
    }
}