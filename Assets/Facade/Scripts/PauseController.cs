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
            throw new NotImplementedException();
        }

        public void ClosePanel()
        {
            throw new NotImplementedException();
        }
    }
}
