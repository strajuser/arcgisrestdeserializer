using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// Spectial IValueProdivider to set dependent properties from metadata
    /// </summary>
    public class PropertyDependencyValueProvider : IValueProvider
    {
        private readonly IEnumerable<PropertyDependencyAttribute> _attributes;

        public PropertyDependencyValueProvider(IEnumerable<PropertyDependencyAttribute> attributes)
        {
            _attributes = attributes;
        }

        public void SetValue(object target, object value)
        {
            var valueSource = value;
            foreach (var attribute in _attributes)
            {
                var member = target.GetType().GetMember(attribute.Property).FirstOrDefault();
                if (member == null)
                    continue;

                value = TryGetValue(attribute, valueSource);
                if (attribute is CollectionPropertyDependencyAttribute)
                    TrySetCollection(member, target, value);
                else
                    TrySetValue(member, target, value);
            }
        }

        /// <summary>
        /// Try to get value from <paramref name="value" /> with Path from Attribute 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private object TryGetValue(PropertyDependencyAttribute attribute, object value)
        {
            if (String.IsNullOrEmpty(attribute.Path))
                return value;

            var valueMember = value.GetType().GetProperty(attribute.Path);
            if (valueMember == null)
                return value;

            return valueMember.GetValue(value, null);
        }

        /// <summary>
        /// Try to fill collection
        /// </summary>
        /// <param name="member"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        private void TrySetCollection(MemberInfo member, object target, object value)
        {
            var prop = member as PropertyInfo;
            if (prop == null)
                return;

            var list = prop.GetValue(target, null) as IList;
            if (list == null)
                return;

            var items = value as IEnumerable;
            if (items != null)
                foreach (var item in items)
                    list.Add(item);
            else list.Add(value);
        }

        /// <summary>
        /// Try to set simple value
        /// </summary>
        /// <param name="member"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        private void TrySetValue(MemberInfo member, object target, object value)
        {
            var valueProvider = new ReflectionValueProvider(member);
            valueProvider.SetValue(target, value);
        }

        public object GetValue(object target)
        {
            return null;
        }
    }
}