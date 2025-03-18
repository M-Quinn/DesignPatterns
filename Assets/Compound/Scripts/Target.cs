using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Action Die;

    private void OnTriggerEnter(Collider other)
    {
        Die?.Invoke();
    }
}
