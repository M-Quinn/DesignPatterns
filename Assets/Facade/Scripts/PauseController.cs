using System;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Facade
{
    public class PauseController : MonoBehaviour
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
    }
}
