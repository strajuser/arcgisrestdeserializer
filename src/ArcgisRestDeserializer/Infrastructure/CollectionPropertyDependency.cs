using System;

namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// Attribute for fillind dependent collections in seriazlization
    /// </summary>
    public class CollectionPropertyDependencyAttribute : PropertyDependencyAttribute
    {
        public CollectionPropertyDependencyAttribute(string property, string path = null) : base(property, path)
        {
        }
    }
}