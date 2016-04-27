using System;
using System.Collections;
using System.Collections.Generic;

namespace Mapogee
{
    public class LayerCollection : ICollection<ILayer>
    {
        private readonly IList<ILayer> _layers = new List<ILayer>();

        public event EventHandler<EventArgs<ILayer>> LayerRemoved;
        public event EventHandler<EventArgs<ILayer>> LayerAdded;
        
        public void Add(ILayer layer)
        {
            _layers.Add(layer);
            OnLayerAdded(layer);
        }

        public void Clear()
        {
            _layers.Clear();
        }

        public bool Contains(ILayer remove)
        {
            return _layers.Contains(remove);
        }

        public void CopyTo(ILayer[] array, int arrayIndex)
        {
            _layers.CopyTo(array, arrayIndex);
        }

        bool ICollection<ILayer>.Remove(ILayer layer)
        {
            return _layers.Remove(layer);
        }

        public int Count => _layers.Count;

        public bool IsReadOnly => _layers.IsReadOnly;

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

        public IEnumerator<ILayer> GetEnumerator()
        {
            return _layers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
