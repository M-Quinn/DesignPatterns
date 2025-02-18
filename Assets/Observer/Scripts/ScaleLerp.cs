using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace DesignPatterns.Observer
{
    public class ScaleLerp : MonoBehaviour, IObserver
    {
        [SerializeField] private GameObject capsule;

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
                lerpCoroutine = StartCoroutine(lerpScaleEnumerator());
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

                    capsule.transform.localScale = new Vector3(scale, scale, scale);

                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                capsule.transform.localScale = new Vector3(maxSize, maxSize, maxSize);
                elapsedTime = 0;
                while (elapsedTime <= totalTime)
                {
                    while (!_isLerping)
                        yield return null;

                    var t = elapsedTime / totalTime;

                    float scale = Mathf.Lerp(maxSize, minSize, t);

                    capsule.transform.localScale = new Vector3(scale, scale, scale);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                capsule.transform.localScale = new Vector3(minSize, minSize, minSize);

                yield return null;
            }
        }
    }
}
