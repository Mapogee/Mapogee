using System;
using System.Collections;
using System.Collections.Generic;

namespace Mapogee
{
    public class LayerCollection : ICollection<ILayer>
    {
        private readonly List<ILayer> _layers = new List<ILayer>();

        public event EventHandler<EventArgs<ILayer>> LayerRemoved;
        public event EventHandler<EventArgs<ILayer>> LayerAdded;
        
        public void Add(ILayer layer)
        {
            _layers.Add(layer);
            OnLayerAdded(layer);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ILayer item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ILayer[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<ILayer>.Remove(ILayer item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }

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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
