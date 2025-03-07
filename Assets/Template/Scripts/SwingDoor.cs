using System.Collections;
using UnityEngine;

namespace DesignPatterns.Template
{
    public class Door : Interactable
    {
        Coroutine _coroutine;
        
        void Start()
        {
            transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0.47f, 0.27f, 0.06f);
            
        }

        public override void PerformInteraction()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(SwingDoorRoutine());
        }

        IEnumerator SwingDoorRoutine()
        {
            float totalTime = 1.4f;
            float elapsedTime = 0;
            float value;

            
            while (elapsedTime / totalTime <= 1.0f)
            {
                elapsedTime += Time.deltaTime;
                value = elapsedTime / totalTime;

                transform.rotation = Quaternion.Euler(0, Mathf.LerpAngle(0, -90, value), 0);
                yield return null;
            }
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

    }
}
