using System;
using System.Runtime.Serialization;
using ArcgisRestDeserializer.Infrastructure;
using ArcgisRestDeserializer.Metadata.Converters;
using ESRI.ArcGIS.Client.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Tests.Metadata.Converters
{
    public abstract class SymbolConverterTestsBase
    {
        protected void AssertType<T>(string type) where T : Symbol
        {
            string data = String.Format("{{\"type\":\"{0}\"}}", type);
            var rez = JsonConvert.DeserializeObject<Symbol>(data, CreateSettings(new SymbolConverter()));
            Assert.IsTrue(rez is T);
        }

        private JsonSerializerSettings CreateSettings(params JsonConverter[] converters)
        {
            return new JsonSerializerSettings
            {
                Converters = converters,
                ContractResolver = CreateResolver()
            };
        }

        protected abstract DefaultContractResolver CreateResolver();

        #region | Metadata Nested Classes |

        [DataContract]
        public class SymbolMetadata { }

        #endregion 
    }
}