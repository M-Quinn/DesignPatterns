using UnityEngine;

namespace DesignPatterns.ChainOfResponsibility
{
    public class DamageHandler
    {
        protected DamageHandler NextHandler;

        public DamageHandler SetNextHandler(DamageHandler handler)
        {
            NextHandler = handler;
            return handler;
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