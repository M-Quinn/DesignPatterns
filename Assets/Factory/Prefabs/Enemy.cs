using UnityEngine;

namespace DesignPatterns.Factory
{
    public class Enemy : MonoBehaviour
    {
        public Color Color { get; set; }
        public string Weapon { get; set; }

        public virtual void Init(Color color, string weapon)
        {
            Color = color;
            Weapon = weapon;
            GetComponent<Renderer>().material.color = Color;
        }
    }
}
