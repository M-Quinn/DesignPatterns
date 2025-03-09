using UnityEngine;

namespace DesignPatterns.Composite
{
    public class Item : ItemComponent
    {
        string _name;
        public Item(string name)
        {
            _name = name;
        }

        public override string GetName()
        {
            return _name;
        }
    }
}
