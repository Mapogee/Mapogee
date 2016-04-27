using NUnit.Framework;

namespace Mapogee.Tests
{
    [TestFixture]
    public class LayerCollectionTests
    {
        [Test]
        public void TestAddLayer()
        {
            // arrange
            var layerCollection = new LayerCollection();
            var layer = new Layer();
            ILayer addedLayer = null;
            layerCollection.LayerAdded += (sender, args) => addedLayer = args.Value;
            
            // act
            layerCollection.Add(layer);

            // assert
            Assert.AreEqual(1, layerCollection.Count);
            Assert.AreEqual(layer, addedLayer);

        }

        [Test]
        public void TestRemoveLayer()
        {
            // arrange
            var layerCollection = new LayerCollection();
            ILayer notifiedLayer = null;
            var layer = new Layer();
            layerCollection.Add(layer);
            layerCollection.LayerRemoved += (sender, args) => notifiedLayer = args.Value;

            // act
            layerCollection.Remove(layer);

            // assert
            Assert.AreEqual(0, layerCollection.Count);
            Assert.AreEqual(notifiedLayer, layer);
        }

        [Test]
        public void TestCollectionImplementation()
        {
            // arrange
            var layerCollection = new LayerCollection();
            var layer1 = new Layer();
            var layer2 = new Layer();
            layerCollection.Add(layer1);
            layerCollection.Add(layer2);
            var counter = 0;

            // act
            foreach (var layer in layerCollection)
            {
                if (layer != null) counter++;
            }
            var array = new ILayer[layerCollection.Count];
            layerCollection.CopyTo(array, 0);

            var contains = layerCollection.Contains(layer1);
            layerCollection.Clear();


            // assert
            Assert.AreEqual(counter, 2); // GetIterator
            Assert.AreEqual(layerCollection.Count, 0); // Clear
            Assert.AreEqual(array.Length, 2); // CopyTo
        }
    }
}
