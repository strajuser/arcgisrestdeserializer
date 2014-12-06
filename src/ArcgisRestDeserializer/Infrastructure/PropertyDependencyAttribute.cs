using System;

namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// Attribute for creating dependent properies in seriazlization
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PropertyDependencyAttribute : Attribute
    {

        public string Property { get; set; }
        public string Path { get; set; }

        public PropertyDependencyAttribute(string path, string property)
        {
            Path = path;
            Property = property;
        }
    }
}