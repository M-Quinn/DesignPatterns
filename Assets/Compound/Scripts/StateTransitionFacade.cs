using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Compound
{
    public class StateTransitionFacade
    {
        IState _currentState;
        Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
        List<Transition> _currentTransitions = new List<Transition>();
        static List<Transition> _emptyTransitions = new List<Transition>();

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }

        public void Execute()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }

            _currentState?.Tick();
        }

        public void SetState(IState state)
        {
            if (state == _currentState)
                return;

            _currentState?.Exit();

            _currentState = state;
            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null)
            {
                _currentTransitions = _emptyTransitions;
            }

            _currentState.Enter();
        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            if (this._transitions.TryGetValue(from.GetType(), out var _transitions) == false)
            {
                _transitions = new List<Transition>();
                this._transitions[from.GetType()] = _transitions;
            }

            _transitions.Add(new Transition(to, condition));
        }

        Transition GetTransition()
        {
            foreach (var transition in _currentTransitions)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }

            return null;
        }
    }

}