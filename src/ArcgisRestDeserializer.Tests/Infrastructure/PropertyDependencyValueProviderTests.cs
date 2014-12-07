using System.Collections.ObjectModel;
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
            var itemSource = new ItemSource {Name = "SimpleName"};
            var item = new ItemTarget();

            var valueProvider = new PropertyDependencyValueProvider(new[] {attr});
            valueProvider.SetValue(item, itemSource);
            Assert.AreEqual(item.Title, itemSource.Name);
        }

        [TestMethod]
        public void TestReadonlyCollectonPropertyDependency()
        {
            var attr = new CollectionPropertyDependencyAttribute("", "Collection");
            var item = new ItemTarget();

            var valueProvider = new PropertyDependencyValueProvider(new[] { attr });
            valueProvider.SetValue(item, new[] { "1", "2" });
            Assert.AreEqual(item.Collection.Count, 2);
            Assert.AreEqual(item.Collection[0], "1");
            Assert.AreEqual(item.Collection[1], "2");
        }

        #region | Nested Classes |

        public class ItemSource 
        {
            public string Name { get; set; }
        }

        public class ItemTarget
        {
            public string Title { get; set; }

            private readonly ObservableCollection<string> _collection = new ObservableCollection<string>();
            public ObservableCollection<string> Collection
            {
                get { return _collection; }
            }
        }

        #endregion
    }
}