using NUnit.Framework;

namespace Mapogee.Tests
{
    [TestFixture]
    public class MapTests
    {
        [Test]
        public void TestGetLayers()
        {
            // arrange
            var map = new Map();
            map.Layers.Add(new Layer());

            // act
            var layers = map.Layers;

            // assert
            Assert.AreEqual(layers.Count, 1);
        }
    }
}
