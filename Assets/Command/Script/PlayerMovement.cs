using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dev.MikeQ.Command {
    public class PlayerMovement : MonoBehaviour
    {
        public void MoveUp() {
            transform.position += Vector3.forward;
        }
        public void MoveDown() {
            transform.position += Vector3.forward * -1;
        }
        public void MoveRight() {
            transform.position += Vector3.right;
        }
        public void MoveLeft() {
            transform.position += Vector3.right * -1;
        }
    }
}
