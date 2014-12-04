using ArcgisRestDeserializer.Infrastructure;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Tests.Metadata.Converters
{
    [TestClass]
    public class FillSymbolConverterTests : SymbolConverterTestsBase
    {
        [TestMethod]
        public void TestSimpleFillSymbol()
        {
            AssertType<SimpleFillSymbol>("esriSFS");
        }

        [TestMethod]
        public void TestPictureFillSymbol()
        {
            AssertType<PictureFillSymbol>("esriPFS");
        }

        protected override DefaultContractResolver CreateResolver()
        {
            var resolver = new DynamicMetadataContractResolver();
            resolver.RegisterTypeMetadata<SimpleFillSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<PictureFillSymbol, SymbolMetadata>();
            return resolver;
        }
    }
}