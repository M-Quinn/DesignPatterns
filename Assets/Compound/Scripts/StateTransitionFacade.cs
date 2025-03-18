using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Compound
{
    public class StateTransitionFacade
    {
        private IState currentState;
        private Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
        private List<Transition> currentTransitions = new List<Transition>();
        private List<Transition> anyTransitions = new List<Transition>();
        private static List<Transition> EmptyTransitions = new List<Transition>();

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

            currentState?.Tick();
        }

        public void SetState(IState state)
        {
            if (state == currentState)
                return;

            currentState?.Exit();

            currentState = state;
            transitions.TryGetValue(currentState.GetType(), out currentTransitions);
            if (currentTransitions == null)
            {
                currentTransitions = EmptyTransitions;
            }

            currentState.Enter();
        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            if (transitions.TryGetValue(from.GetType(), out var _transitions) == false)
            {
                _transitions = new List<Transition>();
                transitions[from.GetType()] = _transitions;
            }

            _transitions.Add(new Transition(to, condition));
        }

        public void AddAnyTransition(IState to, Func<bool> condition)
        {
            anyTransitions.Add(new Transition(to, condition));
        }

        private Transition GetTransition()
        {
            foreach (var transition in anyTransitions)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }

            foreach (var transition in currentTransitions)
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