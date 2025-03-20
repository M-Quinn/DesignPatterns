using System;
using DesignPatterns.Bridge;
using UnityEngine;

namespace DesignPatterns.Bridge
{
    public class ShortSword : Weapon
    {
        

        public override void Attack()
        {
            Debug.Log("Short Sword is attacking!");
            _weaponEffect.PlayEffect();
        }
    }
}
