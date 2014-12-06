using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// Special ContractResolver for Json.NET that resolve properties with metadata from another class
    /// </summary>
    public class DynamicMetadataContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, Type> _metadataDictionary = new Dictionary<Type, Type>();

        /// <summary>
        /// Register special type with metadata for json deserializing type
        /// </summary>
        /// <param name="type">Deserializing Type</param>
        /// <param name="typeMetadata">Metadata Type</param>
        /// <returns></returns>
        public DynamicMetadataContractResolver RegisterTypeMetadata(Type type, Type typeMetadata)
        {
            if (_metadataDictionary.ContainsKey(type))
                _metadataDictionary[type] = typeMetadata;
            else _metadataDictionary.Add(type, typeMetadata);
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
            if (!_metadataDictionary.ContainsKey(member.DeclaringType))
                property = base.CreateProperty(member, memberSerialization);
            else
            {
                var metadataType = _metadataDictionary[member.DeclaringType];
                var metadataMember = metadataType.GetMember(member.Name).FirstOrDefault();
                if (metadataMember == null)
                    return null;

                property = CreateMetadataProperty(member, metadataMember, memberSerialization);
            }
            return property;
        }

        /// <summary>
        /// Creates IList of properties with extension properties from metadata
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = null;
            if (!_metadataDictionary.ContainsKey(type))
                properties = base.CreateProperties(type, memberSerialization);
            else
            {
                properties = base.CreateProperties(type, memberSerialization);

                var metadataType = _metadataDictionary[type];
                var metadataMembers = GetSerializableMembers(metadataType);
                foreach (var member in metadataMembers.Where(x => !properties.Select(y => y.UnderlyingName).Contains(x.Name)))
                {
                    var property = base.CreateProperty(member, memberSerialization);
                    property.DeclaringType = type;
                    var attributes =
                        Attribute.GetCustomAttributes(member, typeof(PropertyDependencyAttribute))
                            .OfType<PropertyDependencyAttribute>();
                    property.ValueProvider = new PropertyDependencyValueProvider(attributes);
                    properties.Add(property);
                }

                IList<JsonProperty> orderedProperties = properties.OrderBy(p => p.Order ?? -1).ToList();
                return orderedProperties;
            }
            return properties;
        }

        private JsonProperty CreateMetadataProperty(MemberInfo member, MemberInfo metadataMember, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(metadataMember, memberSerialization);
            property.DeclaringType = member.DeclaringType;
            var attributes =
                Attribute.GetCustomAttributes(metadataMember, typeof(PropertyDependencyAttribute))
                    .OfType<PropertyDependencyAttribute>();
            property.ValueProvider = !attributes.Any()
                ? (IValueProvider)new ReflectionValueProvider(member)
                : new PropertyDependencyValueProvider(attributes);
            return property;
        }
    }
}