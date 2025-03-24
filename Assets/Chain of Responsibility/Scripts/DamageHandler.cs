using UnityEngine;

namespace DesignPatterns.ChainOfResponsibility
{
    public class DamageHandler
    {
        protected DamageHandler NextHandler;

        public void SetNextHandler(DamageHandler handler)
        {
            if (NextHandler == null)
            {
                NextHandler = handler;
            }
            else
            {
                NextHandler.SetNextHandler(handler);
            }
        }

        public virtual float HandleDamage(float damage, string tag)
        {
            if (NextHandler != null)
            {
                return NextHandler.HandleDamage(damage, tag);
            }
            Debug.LogWarning($"No handler found for {tag}");
            return damage;
        }
    }


}