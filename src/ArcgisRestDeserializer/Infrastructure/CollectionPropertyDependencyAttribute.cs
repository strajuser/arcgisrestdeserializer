namespace ArcgisRestDeserializer.Infrastructure
{
    /// <summary>
    /// Attribute for filling dependent collections during serialization
    /// </summary>
    public class CollectionPropertyDependencyAttribute : PropertyDependencyAttribute
    {
        public CollectionPropertyDependencyAttribute(string property, string path = null) : base(property, path)
        {
        }
    }
}