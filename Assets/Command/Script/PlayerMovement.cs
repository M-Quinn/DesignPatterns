using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Command
{
    public class PlayerMovement : MonoBehaviour
    {
        public void Move(Vector3 direction, Text textbox) {
            textbox.text =  CheckMovement(direction);
        }

        private string CheckMovement(Vector3 direction)
        {
            if (Physics.Raycast(transform.position, direction, 1))
            {
                return "Failed";
            }
            transform.position += direction;
            return "Success";
        }
    }
}
