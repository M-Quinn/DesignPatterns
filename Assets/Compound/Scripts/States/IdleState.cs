using System;
using UnityEngine;

namespace DesignPatterns.Compound
{
    public class IdleState : IState
    {
        private Material _mat;
        private Transform _self;
        private Action<GameObject> FoundTarget;

        public IdleState(Material mat, Transform self, Action<GameObject> foundTarget)
        {
            _mat = mat;
            _self = self;
            FoundTarget = foundTarget;
        }

        public void Enter()
        {
            _mat.color = Color.blue;
        }

        public void Exit()
        {
            _mat.color = Color.white;
        }

        public void Tick()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_self.position, 50f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent<Target>(out var target))
                {
                    FoundTarget?.Invoke(hitCollider.gameObject);
                }
            }
        }
    }
}
