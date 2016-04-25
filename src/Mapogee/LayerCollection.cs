using System;
using System.Collections.Generic;

namespace Mapogee
{
    public class LayerCollection
    {
        private readonly List<ILayer> _layers = new List<ILayer>();

        public event EventHandler< LayerRemoved;
        public event EventHandler<EventArgs> LayerAdded;
        public event EventHandler<EventArgs> LayerMoved;

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
