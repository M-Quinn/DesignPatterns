using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Proxy
{
    public class SceneController : MonoBehaviour
    {
        private Camera _mainCamera;

        private List<Key> _keys = new List<Key>();

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.transform.TryGetComponent<Key>(out var key))
                    {
                        _keys.Add(key);
                        Destroy(hit.transform.gameObject);
                        Debug.Log("Key picked up");
                    }
                    else if (hit.transform.parent.TryGetComponent<IDoor>(out IDoor door))
                    {
                        foreach (Key k in _keys)
                        {
                            door.Open(k);
                        }
                    }
                }
            }
        }
    }
}
