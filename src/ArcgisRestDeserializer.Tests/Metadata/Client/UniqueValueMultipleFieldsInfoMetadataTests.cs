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
    public class UniqueValueMultipleFieldsInfoMetadataTests : MetadataTestsBase
    {
        [TestMethod]
        public void TestUniqueValueMultipleFieldsInfoMetadata()
        {
            const string data = @"{
  ""value"" : ""1,2"", 
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
            var rez = JsonConvert.DeserializeObject<UniqueValueMultipleFieldsInfo>(data, CreateSettings());
            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.Label, "Duct Bank");
            Assert.AreEqual(rez.Description, "Duct Bank description");

            var symbol = rez.Symbol as SimpleLineSymbol;
            Assert.IsNotNull(symbol);
            Assert.AreEqual(symbol.Style, SimpleLineSymbol.LineStyle.Dash);
            Assert.AreEqual(symbol.Width, 1);

            Assert.AreEqual(rez.Values.Length, 2);
            Assert.AreEqual(rez.Values[0], 1);
            Assert.AreEqual(rez.Values[1], 2);
        }

        protected override DynamicMetadataContractResolver CreateResolver()
        {
            return base.CreateResolver()
                .RegisterTypeMetadata<RendererInfo, RendererInfoMetadata>()
                .RegisterTypeMetadata<UniqueValueMultipleFieldsInfo, UniqueValueMultipleFieldsInfoMetadata>()
                .RegisterTypeMetadata<SimpleLineSymbol, SimpleLineSymbolMetadata>()
                .RegisterTypeMetadata<LineSymbol, LineSymbolMetadata>();
        }
    }
}