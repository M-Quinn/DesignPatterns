using UnityEngine;

namespace DesignPatterns.Factory
{
    public class RotateBehavior : MonoBehaviour, ICubeBehavior
    {
        public float Speed = 30f;

        public void ExecuteBehavior()
        {
            transform.Rotate(Vector3.up * Speed * Time.deltaTime);
        }

        public void FixedExecuteBehavior()
        {
            //
        }
    }
}
