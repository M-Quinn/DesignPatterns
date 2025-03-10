using UnityEngine;

namespace DesignPatterns.State
{
    public class CubeController : MonoBehaviour
    {
        private CharacterController _cController;
        private float _playerSpeed = 7.0f;

        Vector3 _userMove;

        private IState _currentState;
        private IState _idleState;
        private IState _sprintState;
        private IState _walkState;

        private void Awake()
        {
            _cController = gameObject.GetComponent<CharacterController>();
            Material mat = GetComponent<Renderer>().material;

            _idleState = new IdleState(mat);
            _walkState = new WalkState(mat, _playerSpeed, _cController);
            _sprintState = new SprintState(mat, _playerSpeed * 1.5f, _cController);

            _currentState = _idleState;
        }

        void Update()
        {
            _userMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            CheckStateChange();

            _currentState.Tick();
        }

        void FixedUpdate()
        {
            _currentState.FixedTick();
        }

        void SetState(IState state)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = state;
            _currentState.Enter();
        }

        void CheckStateChange()
        {
            if (_userMove == Vector3.zero)
            {
                SetState(_idleState);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                SetState(_sprintState);
            }
            else
            {
                SetState(_walkState);
            }
        }
    }
}
