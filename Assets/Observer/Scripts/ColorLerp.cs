using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Observer
{
    public class ColorLerp : MonoBehaviour, IObserver
    {
        [SerializeField] Image _image;

        ISubject _stateSubject;
        bool _isLerping = true;

        Coroutine _lerpCoroutine;

        void OnEnable()
        {
            if (_stateSubject == null)
            {
                _stateSubject = FindObjectsByType<MonoBehaviour>(0).OfType<ISubject>().FirstOrDefault();
            }

            _stateSubject.RegisterObserver(this);

            if (_lerpCoroutine == null)
            {
                _lerpCoroutine = StartCoroutine(lerpColorEnumerator());
            }
        }

        void OnDisable()
        {
            _stateSubject.UnregisterObserver(this);

            StopCoroutine(_lerpCoroutine);
            _lerpCoroutine = null;

        }

        public void UpdateGameState(bool state)
        {
            Debug.Log("Color Lerper state changed to " + state);

            _isLerping = state;
        }

        IEnumerator lerpColorEnumerator()
        {
            float totalTime = 1.0f;
            float elapsedTime = 0;
            while (true)
            {
                elapsedTime = 0;
                while (elapsedTime <= totalTime)
                {
                    while(!_isLerping)
                        yield return null;

                    var t = elapsedTime / totalTime;

                    Color color = Color.Lerp(Color.red, Color.blue, t);
                    _image.color = color;
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                _image.color = Color.blue;
                elapsedTime = 0;
                while (elapsedTime <= totalTime)
                {
                    while (!_isLerping)
                        yield return null;

                    var t = elapsedTime / totalTime;

                    Color color = Color.Lerp(Color.blue, Color.red, t);

                    _image.color = color;
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                _image.color = Color.red;
                yield return null;
            }
        }
    }
}
