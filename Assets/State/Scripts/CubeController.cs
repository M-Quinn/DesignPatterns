using UnityEngine;

namespace DesignPatterns.State
{
    public class CubeController : MonoBehaviour
    {
        private CharacterController controller;
        private float playerSpeed = 7.0f;

        Vector3 _userMove;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {
            _userMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (_userMove == Vector3.zero)
            {
                Idle();
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                
                Sprint(_userMove);
            }
            else
            {
                Move(_userMove);
            }
        }

        void Idle()
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        void Move(Vector3 movement)
        {
            GetComponent<Renderer>().material.color = Color.green;
            controller.Move(movement *Time.deltaTime * playerSpeed);
        }

        void Sprint(Vector3 movement)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
            controller.Move(movement * Time.deltaTime * playerSpeed * 1.5f);
        }
    }
}
