
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Command {
    public class MoveCommand : ICommand
    {
        PlayerMovement _player;
        Vector3 _direction;
        Text _textbox;

        public MoveCommand(PlayerMovement player, Vector3 direction, Text textbox) {
            _player = player;
            _direction = direction;
            _textbox = textbox;
        }

        public void Execute()
        {
            _player.Move(_direction, _textbox);
        }

        public void Undo()
        {
            _player.Move(-_direction, _textbox);
        }
    }

}

