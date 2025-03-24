using UnityEngine;

namespace DesignPatterns.ChainOfResponsibility
{
    public class WeakHandler : DamageHandler
    {
        public override float HandleDamage(float damage, string tag)
        {
            Debug.Log("Weak Handler checked");
            if (string.Equals(tag.ToLower(), "key"))
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
