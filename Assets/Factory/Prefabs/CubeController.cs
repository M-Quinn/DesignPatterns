using UnityEngine;

namespace DesignPatterns.Factory
{
    public class CubeController : MonoBehaviour
    {
        public ICubeBehavior CubeBehavior;

        void Update()
        {
            if (CubeBehavior != null)
                CubeBehavior.ExecuteBehavior();
        }

        void FixedUpdate()
        {
            if (CubeBehavior != null)
                CubeBehavior.FixedExecuteBehavior();
        }
    }
}
