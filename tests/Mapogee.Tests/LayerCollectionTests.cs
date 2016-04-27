﻿using NUnit.Framework;

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
            var layer = new BaseLayer();
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
            var layer = new BaseLayer();
            layerCollection.Add(layer);
            layerCollection.LayerRemoved += (sender, args) => notifiedLayer = args.Value;

            // act
            layerCollection.Remove(layer);

            // assert
            Assert.AreEqual(0, layerCollection.Count);
            Assert.AreEqual(notifiedLayer, layer);
        }

        [Test]
        public void TestIterator()
        {
            // arrange
            var layerCollection = new LayerCollection();
            layerCollection.Add(new BaseLayer());
            layerCollection.Add(new BaseLayer());
            var counter = 0;

            // act
            foreach (var layer in layerCollection)
            {
                if (layer != null) counter++;
            } 

            // assert
            Assert.AreEqual(counter, layerCollection.Count);
        }

    }
}
