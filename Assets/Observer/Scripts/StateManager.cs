using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Observer
{
    public class StateManager : MonoBehaviour, ISubject
    {
        private bool _gameIsPlaying = true;
        List<IObserver> _observers = new List<IObserver>();

        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonText;

        void OnEnable()
        {
            if (_button != null)
            {
                _button.onClick.AddListener(ToggleGameState);
            }

            if (_buttonText != null)
            {
                _buttonText.text = _gameIsPlaying ? "Pause Game" : "Start Game";
            }
        }

        void OnDisable()
        {
            if (_button != null)
            {
                _button.onClick.RemoveListener(ToggleGameState);
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
                observer.UpdateGameState(_gameIsPlaying);
            }
        }

        void ToggleGameState()
        {
            _gameIsPlaying = !_gameIsPlaying;

            NotifyObservers();
            
            if (_buttonText != null)
            {
                _buttonText.text = _gameIsPlaying ? "Pause Game" : "Start Game";
            }
        }
    }
}
