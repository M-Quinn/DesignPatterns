using UnityEngine;

namespace DesignPatterns.Compound
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] float _speed;
        [Header("References")]
        [SerializeField] Transform _childTransform; 
        [SerializeField] CharacterController _cController;
        [Header("Model References")] 
        [SerializeField] Renderer _renderer;
        
        bool _foundTarget = false;
        GameObject _curTarget = null;

        StateTransitionFacade _stateMachine;
        IState _idleState;
        IState _huntingState;
        IState _returnState;

        void Awake()
        {
            Material mat = _renderer.material;
            
            _stateMachine = new StateTransitionFacade();
            _idleState = new IdleState(mat, _childTransform, (x) => FoundTarget(x));
            _huntingState = new GoToTargetState(_childTransform, ref _curTarget, mat, _cController, ref _speed);
            _returnState = new ReturnToCenter(_childTransform, mat, _cController, ref _speed);
            
            
            _stateMachine.AddTransition(_huntingState, _returnState, TransitionToReturn);
            _stateMachine.AddTransition(_returnState, _idleState, TransitionToIdle);
            _stateMachine.AddTransition(_idleState, _huntingState, TransitionToHunting);
            
            _stateMachine.SetState(_idleState);
        }


        void Update()
        {
            if (_foundTarget && _curTarget.activeInHierarchy == false)
            {
                _foundTarget = false;
                _curTarget = null;
                Debug.Log("Target is null now");
            }
            
            _stateMachine.Execute();
        }


        void FoundTarget(GameObject target)
        {
            _curTarget = target;
            if (target != null)
            {
                ((GoToTargetState)_huntingState).UpdateTarget(_curTarget);
                _foundTarget = true;
            }
        }

        bool TransitionToHunting()
        {
            return _foundTarget;
        }

        bool TransitionToReturn()
        {
            if (!_foundTarget)
            {
                return true;
            }

            return false;
        }

        bool TransitionToIdle()
        {
            if (Vector3.Distance(_childTransform.position, Vector3.zero) < 1 && !_foundTarget)
            {
                return true;
            }

            return false;
        }
    }

}