using System;
using UnityEngine;

namespace DesignPatterns.Compound
{
    public class Target : MonoBehaviour
    {
        public Action Die;

        private void OnTriggerEnter(Collider other)
        {
            Die?.Invoke();
        }
    }
}
