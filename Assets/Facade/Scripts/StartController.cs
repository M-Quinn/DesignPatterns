using System;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Facade
{
    public class StartController : MonoBehaviour
    {
        public Action StartGame;

        [SerializeField] Button _startButton;

        void Awake()
        {
            _startButton.onClick.AddListener(() => StartGame?.Invoke());
        }
    }
}
