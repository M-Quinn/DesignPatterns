using UnityEngine;

namespace DesignPatterns.Builder
{
    public class TotemPoleCreator : MonoBehaviour
    {
        [SerializeField] GameObject totemPrefab;
        
        private TotemDirector _totemDirector = new();
        

        void Start()
        {
            GameObject totemObject = Instantiate(totemPrefab);
            if (totemObject.TryGetComponent<TotemPole>(out var totemPole))
            {
                _totemDirector.ConstructTotem(new WoodenTotemPoleBuilder(totemPole), 2);
            }
        }
    }
}
