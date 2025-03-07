using System.Collections;
using UnityEngine;

namespace DesignPatterns.Template
{
    public class SlideDoor : Interactable
    {
        Coroutine _coroutine;

        void Start()
        {
            transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.47f, 0.77f, 0.06f);
        }

        public override void PerformInteraction()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(SlideDoorRoutine());
        }


        IEnumerator SlideDoorRoutine()
        {
            float totalTime = 1.4f;
            float elapsedTime = 0;
            float value;


            while (elapsedTime / totalTime <= 1.0f)
            {
                elapsedTime += Time.deltaTime;
                value = elapsedTime / totalTime;

                transform.position = new Vector3(0, Mathf.Lerp(0, -2, value), 0);
                yield return null;
            }
            transform.position = new Vector3(0, -2, 0);
        }
    }
}
