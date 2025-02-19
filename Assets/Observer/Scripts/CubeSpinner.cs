using System.Linq;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class CubeSpinner : MonoBehaviour, IObserver
    {
        [SerializeField] GameObject _cube;

        bool _isSpinning = true;

        ISubject _stateSubject;

        void OnEnable()
        {
            if (_stateSubject == null)
            {
                _stateSubject = FindObjectsByType<MonoBehaviour>(0).OfType<ISubject>().FirstOrDefault();
            }

            _stateSubject.RegisterObserver(this);
        }

        void OnDisable()
        {
            _stateSubject.UnregisterObserver(this);
        }

        void Update()
        {
            if (_isSpinning)
            {
                _cube.transform.Rotate(new Vector3(0,16 *Time.deltaTime,0));
            }
        }

        public void UpdateGameState(bool state)
        {
            Debug.Log("Cube Spinner got the update " + state);
            _isSpinning = state;
        }
    }
}
