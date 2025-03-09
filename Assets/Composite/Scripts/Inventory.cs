using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Composite
{
    public class Inventory
    {
        public List<Item> Items { get; private set; } = new List<Item>();
        public Inventory()
        {
            Items.Add(new Item("Bronze Sword"));
            Items.Add(new Item("Broken Bowl"));
            Items.Add(new Item("Glasses"));
            Items.Add(new Item("Steel Boots"));
        }
    }
}
