using UnityEngine;

namespace DesignPatterns.Proxy
{
    public class SceneController : MonoBehaviour
    {
        private Camera _mainCamera;

        private bool _hasKey;

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
                    if (hit.transform.CompareTag("Key"))
                    {
                        _hasKey = true;
                        Destroy(hit.transform.gameObject);
                        Debug.Log("Key picked up");
                    }
                    else if (hit.transform.parent.TryGetComponent<IDoor>(out IDoor door))
                    {
                        door.Open(_hasKey);
                    }
                }
            }
        }
    }
}
