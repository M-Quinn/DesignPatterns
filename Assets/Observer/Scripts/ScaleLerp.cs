using System.Collections;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class ScaleLerp : MonoBehaviour, IObserver
    {
        [SerializeField] GameObject _capsule;

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
                _lerpCoroutine = StartCoroutine(lerpScaleEnumerator());
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
            Debug.Log("Scale Lerper state changed to " + state);

            _isLerping = state;
        }

        IEnumerator lerpScaleEnumerator()
        {
            float totalTime = 1.0f;
            float elapsedTime = 0;
            float maxSize = 3;
            float minSize = 1;
            while (true)
            {
                elapsedTime = 0;
                while (elapsedTime <= totalTime)
                {
                    while (!_isLerping)
                        yield return null;

                    var t = elapsedTime / totalTime;

                    float scale = Mathf.Lerp(minSize, maxSize, t);

                    _capsule.transform.localScale = new Vector3(scale, scale, scale);

                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                _capsule.transform.localScale = new Vector3(maxSize, maxSize, maxSize);
                elapsedTime = 0;
                while (elapsedTime <= totalTime)
                {
                    while (!_isLerping)
                        yield return null;

                    var t = elapsedTime / totalTime;

                    float scale = Mathf.Lerp(maxSize, minSize, t);

                    _capsule.transform.localScale = new Vector3(scale, scale, scale);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                _capsule.transform.localScale = new Vector3(minSize, minSize, minSize);

                yield return null;
            }
        }
    }
}
