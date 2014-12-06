using System.Collections.Generic;
using System.Linq;
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
            foreach (var attribute in _attributes)
            {
                var member = target.GetType().GetMember(attribute.Property).FirstOrDefault();
                var valueMember = value.GetType().GetProperty(attribute.Path);
                if (member == null || valueMember == null)
                    continue;

                var valueProvider = new ReflectionValueProvider(member);
                valueProvider.SetValue(target, valueMember.GetValue(value, null));
            }
        }

        public object GetValue(object target)
        {
            return null;
        }
    }
}