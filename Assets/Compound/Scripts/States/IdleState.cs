using System;
using UnityEngine;

namespace DesignPatterns.Compound
{
    public class IdleState : IState
    {
        Material _mat;
        Transform _playerObject;
        Action<GameObject> _foundTarget;

        public IdleState(Material mat, Transform playerObject, Action<GameObject> foundTarget)
        {
            _mat = mat;
            _playerObject = playerObject;
            _foundTarget = foundTarget;
        }

        public void Enter()
        {
            _mat.color = Color.blue;
            Debug.Log("Entering ReturnToTarget");
        }

        public void Exit()
        {
            _mat.color = Color.white;
        }

        public void Tick()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_playerObject.position, 50f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent<Target>(out var target))
                {
                    _foundTarget?.Invoke(hitCollider.gameObject);
                }
            }
        }
    }
}
