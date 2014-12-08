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
    public class RendererInfoMetadataTestses : MetadataTestsBase
    {
        [TestMethod]
        public void TestRendererInfoMetadata()
        {
            const string data = @"{
    ""label"" : ""Duct Bank"", 
    ""description"" : ""Duct Bank description"",
    ""symbol"" : 
          {
            ""type"" : ""esriSLS"", 
            ""style"" : ""esriSLSDash"", 
            ""color"" : [76,0,163,255], 
            ""width"" : 1
          }
}";
            var rez = JsonConvert.DeserializeObject<RendererInfo>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.Label, "Duct Bank");
            Assert.AreEqual(rez.Description, "Duct Bank description");

            var symbol = rez.Symbol as SimpleLineSymbol;
            Assert.IsNotNull(symbol);
            Assert.AreEqual(symbol.Style, SimpleLineSymbol.LineStyle.Dash);
            Assert.AreEqual(symbol.Width, 1);
        }

        protected override DynamicMetadataContractResolver CreateResolver()
        {
            return base.CreateResolver()
                .RegisterTypeMetadata<RendererInfo, RendererInfoMetadata>()
                .RegisterTypeMetadata<SimpleLineSymbol, SimpleLineSymbolMetadata>()
                .RegisterTypeMetadata<LineSymbol, LineSymbolMetadata>();
        }
    }
}