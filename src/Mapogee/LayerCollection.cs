using System;
using System.Collections.Generic;

namespace Mapogee
{
    public class LayerCollection
    {
        private readonly List<ILayer> _layers = new List<ILayer>();

        public event EventHandler<EventArgs<ILayer>> LayerRemoved;
        public event EventHandler<EventArgs<ILayer>> LayerAdded;
        
        public void Add(ILayer layer)
        {
            _layers.Add(layer);
            OnLayerAdded(layer);
        }

        public void Remove(ILayer layer)
        {
            _layers.Remove(layer);
            OnLayerRemoved(layer);
        }

        private void OnLayerRemoved(ILayer layer)
        {
            var handler = LayerRemoved;
            handler?.Invoke(this, new EventArgs<ILayer>(layer));
        }

        private void OnLayerAdded(ILayer layer)
        {
            var handler = LayerAdded;
            handler?.Invoke(this, new EventArgs<ILayer>(layer));
        }
    }
}
