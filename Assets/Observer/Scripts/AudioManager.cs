using System;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class AudioManager : MonoBehaviour, IObserver
    {
        ISubject stateSubject;

        void OnEnable()
        {
            if (stateSubject == null)
            {
                stateSubject = FindObjectsByType<MonoBehaviour>(0).OfType<ISubject>().FirstOrDefault();
            }

            stateSubject.RegisterObserver(this);
        }

        void OnDisable()
        {
            stateSubject.UnregisterObserver(this);
        }

        public void UpdateGameState(bool state)
        {
            Debug.Log("Audio Manager state changed to " + state);
        }
    }
}
