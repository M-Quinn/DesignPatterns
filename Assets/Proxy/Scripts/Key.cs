using UnityEngine;

namespace DesignPatterns.Proxy
{
    public class Key : MonoBehaviour
    {
        public Color Color;
        public string KeyString;

        void Start()
        {
            GetComponent<Renderer>().material.color = Color;
        }
    }
}
