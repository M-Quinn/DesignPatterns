using UnityEngine;

namespace DesignPatterns.Compound
{
    public class ReturnToCenter : IState
    {
        Transform _playerTransform;
        Material _mat;
        CharacterController _cController;
        float _speed;

        public ReturnToCenter(Transform playerTransfrom, Material mat, CharacterController cController, ref float speed)
        {
            _playerTransform = playerTransfrom;
            _mat = mat;
            _cController = cController;
            _speed = speed;
        }

        public void Enter()
        {
            _mat.color = Color.green;
            Debug.Log("Entering Hunting");
        }

        public void Exit()
        {
            _mat.color = Color.white;
        }

        public void Tick()
        {
            Vector3 direction = -_playerTransform.position.normalized;
            direction.y = 0;
            _cController.Move(direction * _speed * Time.deltaTime);
        }
    }

}