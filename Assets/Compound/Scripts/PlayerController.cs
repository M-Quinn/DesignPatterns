using UnityEngine;

namespace DesignPatterns.Compound
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private float _speed;
        [Header("References")]
        [SerializeField] CharacterController _cController;
        [Header("Model References")] 
        [SerializeField] private Material _mat;
        private bool _foundTarget = false;
        private GameObject _curTarget = null;

        private StateTransitionFacade _stateMachine;

        void Awake()
        {
            _stateMachine = new StateTransitionFacade();
            IState idleState = new IdleState(_mat, transform, (x) => FoundTarget(x));
            IState huntingState = new GoToTargetState(transform, ref _curTarget, _mat, _cController, ref _speed);
            IState returnState = new ReturnToCenter(_mat, _cController, ref _speed);
            
            
            
            _stateMachine.AddAnyTransition(huntingState, TransitionToHunting);
            _stateMachine.AddTransition(huntingState, returnState, TransitionToReturn);
            _stateMachine.AddTransition(returnState, idleState, TransitionToIdle);
            
            _stateMachine.SetState(idleState);
        }


        void Update()
        {
            if (_foundTarget && _curTarget.activeInHierarchy == false)
            {
                _foundTarget = false;
                _curTarget = null;
            }
            
            _stateMachine.Execute();
        }


        void FoundTarget(GameObject target)
        {
            _curTarget = target;
            _foundTarget = true;
        }

        bool TransitionToHunting()
        {
            return _foundTarget;
        }

        bool TransitionToReturn()
        {
            if (transform.position.x != 0 && transform.position.z != 0 && !_foundTarget)
            {
                return true;
            }

            return false;
        }

        bool TransitionToIdle()
        {
            if (transform.position.x == 0 && transform.position.z == 0 && !_foundTarget)
            {
                return true;
            }

            return false;
        }
    }

}