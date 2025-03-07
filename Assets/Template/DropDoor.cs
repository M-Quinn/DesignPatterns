using UnityEngine;

namespace DesignPatterns.Template
{
    public class DropDoor : Interactable
    {
        Coroutine _coroutine;
        private Rigidbody _rb;

        void Start()
        {
            transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.87f, 0.27f, 0.06f);
            _rb = transform.GetChild(0).GetComponent<Rigidbody>();
        }

        public override void PerformInteraction()
        {
            _rb.AddForce(Vector3.back*10f, ForceMode.Impulse);
        }



    }

}