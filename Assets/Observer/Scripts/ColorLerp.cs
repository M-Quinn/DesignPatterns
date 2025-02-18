using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Observer
{
    public class ColorLerp : MonoBehaviour, IObserver
    {
        [SerializeField] private Image _image;

        ISubject stateSubject;
        private bool _isLerping = true;

        Coroutine lerpCoroutine;

        void OnEnable()
        {
            if (stateSubject == null)
            {
                stateSubject = FindObjectsByType<MonoBehaviour>(0).OfType<ISubject>().FirstOrDefault();
            }

            stateSubject.RegisterObserver(this);

            if (lerpCoroutine == null)
            {
                lerpCoroutine = StartCoroutine(lerpColorEnumerator());
            }
        }

        void OnDisable()
        {
            stateSubject.UnregisterObserver(this);

            StopCoroutine(lerpCoroutine);
            lerpCoroutine = null;

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
