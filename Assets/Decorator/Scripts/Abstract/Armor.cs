using UnityEngine;

namespace DesignPatterns.Decorator
{
    public abstract class Armor
    {
        public string description = "Unknown";

        public virtual string GetDescription()
        {
            return description;
        }

        public abstract float GetArmorStats();
    }
}
