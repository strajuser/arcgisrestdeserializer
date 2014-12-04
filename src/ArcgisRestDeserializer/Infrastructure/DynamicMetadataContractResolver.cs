using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// Special DefaultContractResolver for Json.NET that resolve properties with metadata from another class
    /// </summary>
    public class DynamicMetadataContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, Type> _metadataDictionaty = new Dictionary<Type, Type>();

        /// <summary>
        /// Register special type with metadata for json deserializing type
        /// </summary>
        /// <param name="type">Deserializing Type</param>
        /// <param name="typeMetadata">Metadata Type</param>
        /// <returns></returns>
        public DynamicMetadataContractResolver RegisterTypeMetadata(Type type, Type typeMetadata)
        {
            if (_metadataDictionaty.ContainsKey(type))
                _metadataDictionaty[type] = typeMetadata;
            else _metadataDictionaty.Add(type, typeMetadata);
            return this;
        }

        /// <summary>
        /// Register special type with metadata for json deserializing type
        /// </summary>
        /// <typeparam name="T">Deserializing Type</typeparam>
        /// <typeparam name="TMetadata">Metadata Type</typeparam>
        /// <returns></returns>
        public DynamicMetadataContractResolver RegisterTypeMetadata<T, TMetadata>()
        {
            return RegisterTypeMetadata(typeof(T), typeof(TMetadata));
        }

        /// <summary>
        /// Creates JsonProperty from metadata type
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property;
            if (!_metadataDictionaty.ContainsKey(member.DeclaringType))
                property = base.CreateProperty(member, memberSerialization);
            else
            {
                var metadataType = _metadataDictionaty[member.DeclaringType];
                var metadataMemberInfo = metadataType.GetMember(member.Name).First();
                property = base.CreateProperty(metadataMemberInfo, memberSerialization);
                property.DeclaringType = member.DeclaringType;
                property.ValueProvider = new ReflectionValueProvider(member);
            }
            return property;
        }

        /// <summary>
        /// Creates list of JsonProperties from metadata type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties;
            if (!_metadataDictionaty.ContainsKey(type))
                properties = base.CreateProperties(type, memberSerialization);
            else
            {
                var metadataType = _metadataDictionaty[type];
                properties = base.CreateProperties(type, memberSerialization);
                var metadataProperties = base.CreateProperties(metadataType, memberSerialization);
                properties = properties.Where(x => metadataProperties.Select(y => y.UnderlyingName).Contains(x.UnderlyingName)).ToList();
            }
            return properties;
        }
    }
}