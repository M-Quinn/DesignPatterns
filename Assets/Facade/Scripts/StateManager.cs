using UnityEngine;

namespace DesignPatterns.Facade
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private PauseController _pauseController;
        [SerializeField] private StartController _startController;

        void Start()
        {
            _gameController.PauseGame += OpenPausePanel;
            _startController.StartGame += OpenGamePanel;
            _pauseController.StartPanel += OpenStartPanel;
            _pauseController.GamePanel += OpenGamePanel;

            OpenStartPanel();
        }

        void OpenPausePanel()
        {
        }

        void OpenGamePanel()
        {
        }

        void OpenStartPanel()
        {
        }
    }
}
