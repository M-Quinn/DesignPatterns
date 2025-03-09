using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Composite
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
            if (_index < _items.Count)
            {
                return true;
            }

            _index = 0;
            return false;
        }

        public object Next()
        {
            return _items[_index++]; ;
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
