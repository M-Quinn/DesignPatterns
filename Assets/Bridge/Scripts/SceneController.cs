using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Bridge
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private List<Weapon> weapons;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (Weapon w in weapons)
                {
                    w.Attack();
                }
            }
        }
    }
}
