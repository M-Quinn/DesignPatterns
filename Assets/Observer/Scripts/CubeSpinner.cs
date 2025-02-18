using System;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class CubeSpinner : MonoBehaviour, IObserver
    {
        [SerializeField] GameObject _cube;

        bool _isStopped = false;

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

        void Update()
        {
            if (!_isStopped)
            {
                _cube.transform.Rotate(new Vector3(0,16 *Time.deltaTime,0));
            }
        }

        public void UpdateGameState(bool state)
        {
            Debug.Log("Cube Spinner got the update " + state);
            _isStopped = state;
        }
    }
}
