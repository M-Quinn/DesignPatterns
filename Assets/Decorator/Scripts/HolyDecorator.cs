using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class HolyDecorator : ArmorDecorator
    {
        public HolyDecorator(Armor baseArmor) : base(baseArmor) { }

        public override string GetDescription()
        {
            return _armor.GetDescription() + ", Blessed (+5)";
        }

        public override float GetArmorStats()
        {
            return _armor.GetArmorStats() + 5;
        }
    }
}
