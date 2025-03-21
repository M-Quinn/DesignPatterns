using UnityEngine;

namespace DesignPatterns.Builder
{
    public class TotemPoleCreator : MonoBehaviour
    {
        [SerializeField] GameObject totemPrefab;
        
        private TotemDirector _totemDirector = new();
        

        void Start()
        {
            GameObject totemObject1 = Instantiate(totemPrefab, new Vector3(1,0,0), Quaternion.identity);            
            GameObject totemObject2 = Instantiate(totemPrefab, new Vector3(-1,0,0), Quaternion.identity);

            if (totemObject1.TryGetComponent<TotemPole>(out var totemPole))
            {
                _totemDirector.ConstructTotem(new WoodenTotemPoleBuilder(totemPole), 2);
            }
            if (totemObject2.TryGetComponent<TotemPole>(out var totemPole1))
            {
                _totemDirector.ConstructTotem(new StoneTotemPoleBuilder(totemPole1), 2);
            }
        }
    }
}
