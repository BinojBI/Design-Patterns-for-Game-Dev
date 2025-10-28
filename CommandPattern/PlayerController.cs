using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace CoommandPattern
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        private CharacterController controller;
        private Vector3 velocity;
        private float gravity = -9.81f;
        [SerializeField]
        private float jumpHeight = 1f;
        private bool isGrounded;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
                velocity.y = -2f;

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        public void Move(Vector3 direction)
        {
            Vector3 move = transform.TransformDirection(direction);
            controller.Move(move * speed * Time.deltaTime);
        }

        public void Jump()
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                Debug.Log("Player jumped!");
            }
        }

        public void Attack()
        {
            Debug.Log("Player attacked!");
            // Play attack animation
        }

    }
}

