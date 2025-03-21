using UnityEngine;

namespace DesignPatterns.Builder
{
    public class TotemPoleCreator : MonoBehaviour
    {
        [SerializeField] GameObject totemPrefab;
        
        private TotemManager totemManager = new();
        

        void Start()
        {
            GameObject totemObject = Instantiate(totemPrefab);
            if (totemObject.TryGetComponent<TotemPole>(out var totemPole))
            {
                totemManager.ConstructTotem(new WoodenTotemPoleBuilder(totemPole), 1);
                totemPole.Display();
            }
        }
    }
}
