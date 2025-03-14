using System;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Facade
{
    public class PauseController : MonoBehaviour, IPanel
    {
        [SerializeField] Button _backToGameButton;
        [SerializeField] Button _exitButton;

        public Action StartPanel;
        public Action GamePanel;

        void Awake()
        {
            _backToGameButton.onClick.AddListener(() => GamePanel?.Invoke());
            _exitButton.onClick.AddListener(() => StartPanel?.Invoke());
        }

        public void OpenPanel()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
