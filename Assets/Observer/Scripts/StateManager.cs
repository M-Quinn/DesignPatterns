using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Observer
{
    public class StateManager : MonoBehaviour, ISubject
    {
        private bool _gameIsPaused = false;
        List<IObserver> _observers = new List<IObserver>();

        [SerializeField] private Button button;

        void OnEnable()
        {
            if (button != null)
            {
                button.onClick.AddListener(ToggleGameState);
            }
        }

        void OnDisable()
        {
            if (button != null)
            {
                button.onClick.RemoveListener(ToggleGameState);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateGameState(_gameIsPaused);
            }
        }

        void ToggleGameState()
        {
            _gameIsPaused = !_gameIsPaused;
            NotifyObservers();
        }
    }
}
