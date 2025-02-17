using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Command
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Text _responseTextbox;
        [SerializeField] PlayerMovement _player;

        public void ButtonClickUp() {
            CreateCommand(Vector3.forward);
        }
        public void ButtonClickDown() {
            CreateCommand(Vector3.forward*-1);
        }
        public void ButtonClickRight() {
            CreateCommand(Vector3.right);
        }
        public void ButtonClickLeft() {
            CreateCommand(Vector3.right*-1);
        }
        public void UndoButton() {
            CommandHandler.UndoCommand();
        }

        private void CreateCommand(Vector3 direction) {
            ICommand command = new MoveCommand(_player, direction, _responseTextbox);
            CommandHandler.ExecuteCommand(command);
        }
    }
}
