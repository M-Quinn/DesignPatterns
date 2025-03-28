using UnityEngine;

namespace DesignPatterns.State
{
    public class SprintState : IState
    {
        private Material _mat;
        private Vector3 _userInput;
        private CharacterController _cController;
        private float _speed;

        public SprintState(Material mat, float speed, CharacterController cController)
        {
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
            _userInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _cController.Move(_userInput * Time.deltaTime * _speed);
        }

        public void FixedTick()
        {
            //
        }
    }
}
