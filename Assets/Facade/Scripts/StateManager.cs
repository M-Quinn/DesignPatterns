using UnityEngine;

namespace DesignPatterns.Facade
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private PauseController _pauseController;
        [SerializeField] private StartController _startController;

        private PanelTransitionFacade _transition = new();

        void Start()
        {
            _gameController.PauseGame += OpenPausePanel;
            _startController.StartGame += OpenGamePanel;
            _pauseController.StartPanel += OpenStartPanel;
            _pauseController.GamePanel += OpenGamePanel;

            _transition.AddPanel(_startController);
            _transition.AddPanel(_gameController);
            _transition.AddPanel(_pauseController);

            _transition.InitPanels(_startController);
        }

        void OpenPausePanel()
        {
            _transition.TransitionPanel(_pauseController);
        }

        void OpenGamePanel()
        {
            _transition.TransitionPanel(_gameController);
        }

        void OpenStartPanel()
        {
            _transition.TransitionPanel(_startController);
        }
    }
}
