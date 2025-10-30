using System.Collections;
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
        [SerializeField]
        private float attackRotateSpeed = 360f;
        private bool isAttacking = false;

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
            if (isAttacking) return;

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
            if (!isAttacking)
            {
                StartCoroutine(AttackRotate());
            }
        }

        private IEnumerator AttackRotate()
        {
            isAttacking = true;
            Debug.Log("Player attacked!");

            float rotated = 0f;

            while (rotated < 360f)
            {
                float rotateStep = attackRotateSpeed * Time.deltaTime;
                transform.Rotate(0f, rotateStep, 0f);
                rotated += rotateStep;
                yield return null;
            }

            // Ensure exact rotation
            Vector3 euler = transform.eulerAngles;
            euler.y = Mathf.Round(euler.y / 360f) * 360f;
            transform.eulerAngles = euler;

            isAttacking = false;
        }

    }
}

