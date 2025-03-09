using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Iterator
{
    public class InventoryIterator : IIterator
    {
        List<Item> _items;
        int _index = 0;

        public InventoryIterator(List<Item> items)
        {
            _items = items;
        }

        public bool HasNext()
        {
            return _index < _items.Count;
        }

        public object Next()
        {
            var value = _items[_index];
            _index = (_index + 1) % _items.Count;
            return value;
        }

        public void Reset()
        {
            _index = 0;
        }

        public bool Add(object value)
        {
            if (value is Item item)
            {
                _items.Add(item);
                return true;
            }

            return false;
        }

        public bool Remove(object value)
        {
            if (value is Item item)
            {
                if (_items.Contains(item))
                {
                    _items.Remove(item);
                    return true;
                }
            }

            return false;
        }
    }
}
