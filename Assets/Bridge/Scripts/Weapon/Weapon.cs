using DesignPatterns.Bridge;
using UnityEngine;

namespace DesignPatterns
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Model References")] 
        [SerializeField] protected Renderer _modelRend;
        [SerializeField] protected Transform _modelTransform;
        [Header("Weapon stats")]
        [SerializeField] protected WeaponEffects _weaponEffectType;
        
        protected IWeaponEffect _weaponEffect;
        
        void Start()
        {
            if (_modelRend != null)
            {
                Material mat =  _modelRend.material;
                
                switch (_weaponEffectType)
                {
                    case WeaponEffects.GROW:
                        _weaponEffect = new GrowEffect(_modelTransform, mat);
                        break;
                    case WeaponEffects.SHRINK:
                        _weaponEffect = new ShrinkEffect(_modelTransform, mat);
                        break;
                }
                if (_weaponEffect == null)
                {
                    Debug.LogError("Weapon effect is null");
                }
                else
                {
                    SetWeaponEffect(_weaponEffect);
                }
            }
        }
        
        void SetWeaponEffect(IWeaponEffect effect)
        {
            _weaponEffect = effect;
        }

        public abstract void Attack();

    }
}
