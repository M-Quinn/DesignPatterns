using UnityEngine;

namespace DesignPatterns.Compound
{
    public class GoToTargetState: IState
    {
        Transform _playerPosition;
        GameObject _targetObject;
        Material _mat;
        CharacterController _cController;
        float _speed;

        public GoToTargetState(Transform playerPosition, ref GameObject targetObject, Material mat,
            CharacterController cController, ref float speed)
        {
            _playerPosition = playerPosition;
            _targetObject = targetObject;
            _mat = mat;
            _cController = cController;
            _speed = speed;
        }

        public void Enter()
        {
            _mat.color = Color.magenta;
            Debug.Log("Entering Hunting");
        }

        public void Exit()
        {
            _mat.color = Color.white;
        }

        public void Tick()
        {
            if (_targetObject != null)
            {
                Vector3 direction = _targetObject.transform.position - _playerPosition.position;
                direction.y = 0;
                _cController.Move(direction.normalized  * _speed * Time.deltaTime);
            }

            
        }

        public void UpdateTarget(GameObject target)
        {
            _targetObject = target;
        }
    }
}
