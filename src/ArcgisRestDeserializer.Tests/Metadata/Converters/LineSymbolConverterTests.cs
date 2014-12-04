using ArcgisRestDeserializer.Infrastructure;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Tests.Metadata.Converters
{
    [TestClass]
    public class LineSymbolConverterTests : SymbolConverterTestsBase
    {
        [TestMethod]
        public void TestSimpleLineSymbol()
        {
            AssertType<SimpleLineSymbol>("esriSLS");
        }

        protected override DefaultContractResolver CreateResolver()
        {
            var resolver = new DynamicMetadataContractResolver();
            resolver.RegisterTypeMetadata<SimpleLineSymbol, SymbolMetadata>();
            return resolver;
        } 
    }
}