using NUnit.Framework;

namespace Mapogee.Tests
{
    [TestFixture]
    public class LayerCollectionTests
    {
        [Test]
        public void TesAddLayer()
        {
            // arrange
            var layerCollection = new LayerCollection();
            
            // act
            layerCollection.Add(new BaseLayer());

            // assert
            Assert.AreEqual(1, layerCollection.Count);

        }
    }
}
