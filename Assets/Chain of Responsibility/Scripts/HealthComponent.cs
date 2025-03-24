using UnityEngine;

namespace DesignPatterns.ChainOfResponsibility
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float _health;
        private DamageHandler _damageHandler = new();

        public void Awake()
        {
            _damageHandler.SetNextHandler(new SteelArmorHandler());
            _damageHandler.SetNextHandler(new WeakHandler());
        }

        public void GetHit(float damage)
        {
            float damageToTake = _damageHandler.HandleDamage(damage, gameObject.tag);
            Debug.Log($"{gameObject.name} to take {damageToTake}/{damage}");
            Debug.Log($"{gameObject.name} health {_health} to {_health - damageToTake} ");

            _health -= damageToTake;
            if (_health <= 0)
            {
                Debug.Log($"{gameObject.name} is now dead");
                Destroy(this.gameObject);
            }

        }
    }
}
