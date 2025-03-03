using System;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Facade
{
    public class StartController : MonoBehaviour, IPanel
    {
        public Action StartGame;

        [SerializeField] Button _startButton;

        void Awake()
        {
            _startButton.onClick.AddListener(() => StartGame?.Invoke());
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
