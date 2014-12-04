using ArcgisRestDeserializer.Infrastructure;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Tests.Metadata.Converters
{
    [TestClass]
    public class SymbolConverterTests : SymbolConverterTestsBase
    {
        [TestMethod]
        public void TestSimpleMarkerSymbol()
        {
            AssertType<SimpleMarkerSymbol>("esriSMS");
        }

        [TestMethod]
        public void TestSimpleFillSymbol()
        {
            AssertType<SimpleFillSymbol>("esriSFS");
        }

        [TestMethod]
        public void TestSimpleLineSymbol()
        {
            AssertType<SimpleLineSymbol>("esriSLS");
        }

        [TestMethod]
        public void TestPictureMarkerSymbol()
        {
            AssertType<PictureMarkerSymbol>("esriPMS");
        }

        [TestMethod]
        public void TestPictureFillSymbol()
        {
            AssertType<PictureFillSymbol>("esriPFS");
        }

        [TestMethod]
        public void TestTextSymbol()
        {
            AssertType<TextSymbol>("esriTS");
        }

        protected override DefaultContractResolver CreateResolver()
        {
            var resolver = new DynamicMetadataContractResolver();
            resolver.RegisterTypeMetadata<Symbol, SymbolMetadata>()
                .RegisterTypeMetadata<MarkerSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<SimpleMarkerSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<PictureMarkerSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<LineSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<SimpleLineSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<FillSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<SimpleFillSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<PictureFillSymbol, SymbolMetadata>()
                .RegisterTypeMetadata<TextSymbol, SymbolMetadata>();
            return resolver;
        }
    }
}