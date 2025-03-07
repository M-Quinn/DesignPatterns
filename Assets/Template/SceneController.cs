using UnityEngine;

namespace DesignPatterns.Template
{
    public class SceneController : MonoBehaviour
    {
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.transform.parent == null)
                    return;

                if (hit.collider.transform.parent.TryGetComponent<Interactable>(out var interactable))
                {
                    if (!interactable.IsInteractable())
                        return;

                    if (Input.GetMouseButtonDown(0))
                        interactable.PerformInteraction();
                }
            }
        }

    }
}
