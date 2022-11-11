using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace dev.MikeQ.Command {
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Text _responseTextbox;
        [SerializeField] PlayerMovement _player;

        public void ButtonClickUp() {
            _responseTextbox.text = _player.MoveUp();
        }
        public void ButtonClickDown() {
            _responseTextbox.text = _player.MoveDown();
        }
        public void ButtonClickRight() {
            _responseTextbox.text = _player.MoveRight();   
        }
        public void ButtonClickLeft() {
            _responseTextbox.text = _player.MoveLeft();
        }
    }

}
