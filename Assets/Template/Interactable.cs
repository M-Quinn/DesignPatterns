using UnityEngine;

namespace DesignPatterns.Template
{
    public abstract class Interactable: MonoBehaviour
    {
        private bool _isInteractable = true;

        public bool IsInteractable()
        {
            return _isInteractable;
        }

        public abstract void PerformInteraction();
    }
}
