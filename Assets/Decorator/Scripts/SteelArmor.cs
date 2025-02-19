using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class SteelArmor : Armor
    {
        public SteelArmor()
        {
            description = "Steel Armor (Base 20)";
        }

        public override float GetArmorStats()
        {
            return 20;
        }
    }
}
