using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ArcgisRestDeserializer.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcgisRestDeserializer.Tests.Infrastructure
{
    [TestClass]
    public class PropertyDependencyValueProviderTests
    {
        [TestMethod]
        public void TestSimpleSourceDependency()
        {
            var attr = new PropertyDependencyAttribute("Title");
            var item = new ItemTarget();

            var valueProvider = new PropertyDependencyValueProvider(new[] { attr });
            valueProvider.SetValue(item, "TestValue");
            Assert.AreEqual(item.Title, "TestValue");
        }

        [TestMethod]
        public void TestSimpleReadonlyCollectonDependency()
        {
            var attr = new CollectionPropertyDependencyAttribute("Collection");
            var item = new ItemTarget();

            var valueProvider = new PropertyDependencyValueProvider(new[] { attr });
            valueProvider.SetValue(item, new[] { "1", "2" });
            Assert.AreEqual(item.Collection.Count, 2);
            Assert.AreEqual(item.Collection[0], "1");
            Assert.AreEqual(item.Collection[1], "2");
        }

        [TestMethod]
        public void TestPropertyFromSourceDependency()
        {
            var attr = new PropertyDependencyAttribute("Title", "Name");
            var itemSource = new ItemSource {Name = "SimpleName"};
            var item = new ItemTarget();

            var valueProvider = new PropertyDependencyValueProvider(new[] {attr});
            valueProvider.SetValue(item, itemSource);
            Assert.AreEqual(item.Title, itemSource.Name);
        }

        [TestMethod]
        public void TestCollectionPropertyFromSourceDependency()
        {
            var attr = new CollectionPropertyDependencyAttribute("Collection", "Names");
            var itemSource = new ItemSource { Names = new [] { "Name1", "Name2" }.ToList()};
            var item = new ItemTarget();

            var valueProvider = new PropertyDependencyValueProvider(new[] { attr });
            valueProvider.SetValue(item, itemSource);

            Assert.AreEqual(item.Collection.Count, itemSource.Names.Count);
            Assert.AreEqual(item.Collection[0], itemSource.Names[0]);
            Assert.AreEqual(item.Collection[1], itemSource.Names[1]);
        }

        #region | Nested Classes |

        public class ItemSource 
        {
            public string Name { get; set; }

            public List<string> Names { get; set; }
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