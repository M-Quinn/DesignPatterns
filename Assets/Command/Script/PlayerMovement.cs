using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dev.MikeQ.Command {
    public class PlayerMovement : MonoBehaviour
    {
        public string MoveUp() {
            return CheckMovement(Vector3.forward);
        }
        public string MoveDown() {
            return CheckMovement(Vector3.forward * -1);
        }
        public string MoveRight() {
            return CheckMovement (Vector3.right);
        }
        public string MoveLeft() {
            return CheckMovement (Vector3.right * -1);
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
