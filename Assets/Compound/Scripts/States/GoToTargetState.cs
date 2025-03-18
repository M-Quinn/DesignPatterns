using UnityEngine;

namespace DesignPatterns.Compound
{
    public class GoToTargetState: IState
    {
        Transform _selfPosition;
        GameObject _targetObject;
        Material _mat;
        CharacterController _cController;
        float _speed;

        public GoToTargetState(Transform selfPosition, ref GameObject targetObject, Material mat,
            CharacterController cController, ref float speed)
        {
            _selfPosition = selfPosition;
            _targetObject = targetObject;
            _mat = mat;
            _cController = cController;
            _speed = speed;
        }

        public void Enter()
        {
            _mat.color = Color.magenta;
        }

        public void Exit()
        {
            _mat.color = Color.white;
        }

        public void Tick()
        {
            _cController.Move(_selfPosition.position - _targetObject.transform.position * _speed * Time.deltaTime);
        }
    }
}
