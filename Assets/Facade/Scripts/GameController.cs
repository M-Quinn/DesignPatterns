using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Facade
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] TMP_Text _moneyTextbox;
        [SerializeField] TMP_Text _applesTextbox;
        [SerializeField] TMP_Text _appleTreesTextbox;
        [SerializeField] Slider _appleTreesSlider;
        [SerializeField] Button _buyAppleTreeButton;
        [SerializeField] Button _sellApplesButton;
        [SerializeField] Button _pauseButton;

        int _money;
        int _apples;
        int _appleTrees = 1;

        bool _isPlaying = true;

        float _delayedTime = 2;
        float _elapsedTime;

        public Action PauseGame;

        void Awake()
        {
            _buyAppleTreeButton.onClick.AddListener(OnBuyAppleTree);
            _sellApplesButton.onClick.AddListener(OnSellApples);
            _pauseButton.onClick.AddListener(() => PauseGame?.Invoke());
        }

        void Update()
        {
            if (_isPlaying)
            {
                _elapsedTime += Time.deltaTime;
                float sliderValue = _elapsedTime / _delayedTime;
                _appleTreesSlider.value = sliderValue;
                if (sliderValue >= 1.0f)
                {
                    _elapsedTime = 0;
                    _apples += _appleTrees * 4;
                }
                UpdateUI();
            }
        }

        void UpdateUI()
        {
            _applesTextbox.text = _apples.ToString();
            _moneyTextbox.text = _money.ToString();
            _appleTreesTextbox.text = _appleTrees.ToString();
        }

        void OnBuyAppleTree()
        {
            if (_money >= 20)
            {
                _appleTrees++;
                _money -= 20;
            }
        }

        void OnSellApples()
        {
            _money += _apples;
            _apples = 0;
        }
    }
}
