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
    public class UniqueValueRendererMetadataTests : MetadataTestBase
    {
        [TestMethod]
        public void TestUniqueValueRendererMetadata()
        {
            // example from http://resources.arcgis.com/en/help/arcgis-rest-api/index.html#/Renderer_objects/02r30000019t000000/
            const string data = @"{
      ""type"" : ""uniqueValue"", 
      ""field1"" : ""SubtypeCD"", 
      ""field2"" : null, 
      ""field3"" : null, 
      ""fieldDelimiter"" : "", "", 
      ""defaultSymbol"" : 
      {
        ""type"" : ""esriSLS"", 
        ""style"" : ""esriSLSSolid"", 
        ""color"" : [130,130,130,255], 
        ""width"" : 1
      }, 
      ""defaultLabel"" : ""\u003cOther values\u003e"", 
      ""uniqueValueInfos"" : [
        {
          ""value"" : ""1"", 
          ""label"" : ""Duct Bank"", 
          ""description"" : ""Duct Bank description"", 
          ""symbol"" : 
          {
            ""type"" : ""esriSLS"", 
            ""style"" : ""esriSLSDash"", 
            ""color"" : [76,0,163,255], 
            ""width"" : 1
          }
        }, 
        {
          ""value"" : ""2"", 
          ""label"" : ""Trench"", 
          ""description"" : ""Trench description"", 
          ""symbol"" : 
          {
            ""type"" : ""esriSLS"", 
            ""style"" : ""esriSLSDot"", 
            ""color"" : [115,76,0,255], 
            ""width"" : 1
          }
        }
      ],
      ""rotationType"": ""geographic"",
      ""rotationExpression"": ""[Rotation] * 2""
}";
            var rez = JsonConvert.DeserializeObject<UniqueValueRenderer>(data, CreateSettings());

            Assert.IsNotNull(rez);
            Assert.AreEqual(rez.DefaultLabel, "\u003cOther values\u003e");
            Assert.AreEqual(rez.Field, "SubtypeCD");

            var defaultSymbol = rez.DefaultSymbol as SimpleLineSymbol;
            Assert.IsNotNull(defaultSymbol);
            Assert.AreEqual(defaultSymbol.Style, SimpleLineSymbol.LineStyle.Solid);
            Assert.AreEqual(defaultSymbol.Width, 1);

            Assert.AreEqual(rez.Infos.Count, 2);
            Assert.AreEqual(rez.Infos[0].Value, "1");
            Assert.AreEqual(rez.Infos[0].Description, "Duct Bank description");
            Assert.AreEqual(rez.Infos[1].Value, "2");
            Assert.AreEqual(rez.Infos[1].Description, "Trench description");
        }

        protected override DynamicMetadataContractResolver CreateResolver()
        {
            return base.CreateResolver()
                .RegisterTypeMetadata<UniqueValueRenderer, UniqueValueRendererMetadata>()
                .RegisterTypeMetadata<RendererInfo, RendererInfoMetadata>()
                .RegisterTypeMetadata<SimpleLineSymbol, SimpleLineSymbolMetadata>()
                .RegisterTypeMetadata<LineSymbol, LineSymbolMetadata>(); 
        }
    }
}