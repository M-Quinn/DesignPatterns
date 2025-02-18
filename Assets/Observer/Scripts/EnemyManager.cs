using System;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class EnemyManager : MonoBehaviour, IObserver
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
            Debug.Log("Enemy Manager state changed to " + state);
        }
    }
}
