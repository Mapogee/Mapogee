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

        public bool Contains(ILayer layer)
        {
            return _layers.Contains(layer);
        }

        public void CopyTo(ILayer[] array, int arrayIndex)
        {
            _layers.CopyTo(array, arrayIndex);
        }



        public int Count => _layers.Count;

        public bool IsReadOnly => _layers.IsReadOnly;

        public bool Remove(ILayer layer)
        {
            var result = _layers.Remove(layer);
            OnLayerRemoved(layer);
            return result;
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
