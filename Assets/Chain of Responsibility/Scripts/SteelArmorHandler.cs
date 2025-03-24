using UnityEngine;

namespace DesignPatterns.ChainOfResponsibility
{
    public class SteelArmorHandler : DamageHandler
    {
        public override float HandleDamage(float damage, string tag)
        {
            Debug.Log("Steel handler checked");
            if (string.Equals(tag.ToLower(), "armor"))
            {
                return damage * 0.6f;
            }
            else
            {
                return base.HandleDamage(damage, tag);
            }
        }
    }
}
