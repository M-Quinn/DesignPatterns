using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class ReinforcedDecorator : ArmorDecorator
    {
        public ReinforcedDecorator(Armor baseArmor) : base(baseArmor) { }

        public override string GetDescription()
        {
            return _armor.GetDescription() + ", Reinforced (+10)";
        }

        public override float GetArmorStats()
        {
            return _armor.GetArmorStats() + 10;
        }
    }
}
