using System;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class AudioManager : MonoBehaviour, IObserver
    {
        [SerializeField] private ISubject stateSubject;

        void OnEnable()
        {
            stateSubject.RegisterObserver(this);
        }

        void OnDisable()
        {
            stateSubject.UnregisterObserver(this);
        }

        public void UpdateGameState(bool state)
        {
            throw new NotImplementedException();
        }
    }
}
