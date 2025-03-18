using UnityEngine;

namespace DesignPatterns.Compound
{
    public class WalkState : IState
    {
        private Material _mat;
        private Vector3 _userInput;
        private CharacterController _cController;
        private float _speed;

        public WalkState(Material mat, float speed, CharacterController cController)
        {
            _mat = mat;
            _cController = cController;
            _speed = speed;
        }

        public void Enter()
        {
            _mat.color = Color.green;
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
