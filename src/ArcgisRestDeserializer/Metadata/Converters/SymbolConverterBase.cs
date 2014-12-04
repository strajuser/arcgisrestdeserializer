using System;
using ArcgisRestDeserializer.Infrastructure;
using ESRI.ArcGIS.Client.Symbols;
using Newtonsoft.Json.Linq;

namespace ArcgisRestDeserializer.Metadata.Converters
{
    /// <summary>
    /// Abstract hierarchy converter base for ESRI.ArcGIS.Client.Symbol classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SymbolConverterBase<T> : JsonCreationConverter<T> where T : Symbol
    {
        public abstract T Create(string type);

        protected override T Create(Type objectType, JObject jsonObject)
        {
            var type = jsonObject["type"].ToString();
            return Create(type);
        }
    }
}