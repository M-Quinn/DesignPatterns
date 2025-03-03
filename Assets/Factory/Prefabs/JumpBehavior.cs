using UnityEngine;

namespace DesignPatterns.Factory
{
    public class JumpBehavior : MonoBehaviour, ICubeBehavior
    {
        public float jumpForce = 5f;
        public float jumpDelay = 2f;

        private float delayTime = 0.0f;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }
        }

        public void ExecuteBehavior()
        {
            //
        }

        public void FixedExecuteBehavior()
        {
            if (Time.time > delayTime)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                delayTime = jumpDelay + Time.time;
            }
        }
    }

}