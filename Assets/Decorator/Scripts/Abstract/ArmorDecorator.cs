using UnityEngine;

namespace DesignPatterns.Decorator
{
    public abstract class ArmorDecorator : Armor
    {
        protected Armor _armor;
        public ArmorDecorator(Armor armor)
        {
            _armor = armor;
        }
    }
}
