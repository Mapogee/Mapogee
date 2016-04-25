using System.Collections.Generic;

namespace Mapogee
{
    public class LayerCollection
    {
        readonly List<ILayer> _layers = new List<ILayer>();

        public void Add(ILayer layer)
        {
            _layers.Add(layer);
        }

        public void Remove(ILayer layer)
        {
            _layers.Remove(layer);
        }
    }
}
