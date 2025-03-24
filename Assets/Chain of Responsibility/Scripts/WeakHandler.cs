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
                return damage * 1.2f;
            }
            else
            {
                return base.HandleDamage(damage, tag);
            }
        }
    }
}
