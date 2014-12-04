using ArcgisRestDeserializer.Infrastructure;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Tests.Metadata.Converters
{
    [TestClass]
    public class MarkerSymbolConverterTests : SymbolConverterTestsBase
    {
        [TestMethod]
        public void TestSimpleMarkerSymbol()
        {
            AssertType<SimpleMarkerSymbol>("esriSMS");
        }

        [TestMethod]
        public void TestPictureMarkerSymbol()
        {
            AssertType<PictureMarkerSymbol>("esriPMS");
        }

        protected override DefaultContractResolver CreateResolver()
        {
            var resolver = new DynamicMetadataContractResolver();
            resolver.RegisterTypeMetadata<MarkerSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<PictureMarkerSymbol, SymbolMetadata>();
            return resolver;
        }
    }
}