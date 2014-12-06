using ArcgisRestDeserializer.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcgisRestDeserializer.Tests.Infrastructure
{
    [TestClass]
    public class PropertyDependencyValueProviderTests
    {
        [TestMethod]
        public void TestSimplePropertyDependency()
        {
            var attr = new PropertyDependencyAttribute("Name", "Title");
            var itemSource = new ItemSource() {Name = "SimpleName"};
            var item = new ItemTarget();

            var valueProvider = new PropertyDependencyValueProvider(new[] {attr});
            valueProvider.SetValue(item, itemSource);
            Assert.AreEqual(item.Title, itemSource.Name);
        }

        #region | Nested Classes |

        public class ItemSource 
        {
            public string Name { get; set; }
        }

        public class ItemTarget
        {
            public string Title { get; set; }
        }

        #endregion
    }
}