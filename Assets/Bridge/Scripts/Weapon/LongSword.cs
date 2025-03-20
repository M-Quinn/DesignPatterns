using DesignPatterns;
using UnityEngine;

public class LongSword : Weapon
{
    public override void Attack()
    {
        Debug.Log("Long Sword is attacking!");
        _weaponEffect.PlayEffect();
    }
}
