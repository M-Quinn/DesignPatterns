using System.Collections.Generic;

namespace DesignPatterns.Composite
{
    public abstract class ItemComponent
    {
        protected List<ItemComponent> Children = new List<ItemComponent>();

        public abstract string GetName();

        public void Add(ItemComponent itemComponent)
        {
            Children.Add(itemComponent);
        }

        public void Remove(ItemComponent itemComponent)
        {
            Children.Remove(itemComponent);
        }

        public ItemComponent GetChild(int i)
        {
            if (i >= 0 && i < Children.Count)
            {
                return Children[i];
            }

            return null;
        }

        public virtual string DisplayInformation()
        {
            return $"Item: " + GetName();
        }
    }
}
