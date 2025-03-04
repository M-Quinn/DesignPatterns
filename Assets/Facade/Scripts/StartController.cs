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
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
