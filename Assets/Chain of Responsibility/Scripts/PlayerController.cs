using UnityEngine;

namespace DesignPatterns.ChainOfResponsibility
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] HealthComponent[] _curTargets;
        [SerializeField] private float _damagePerHit;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var target in _curTargets)
                {
                    target.GetHit(_damagePerHit);
                }
            }
        }
    }
}
