using SingletonPattern;
using UnityEngine;

namespace StatePattern
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private CharacterController controller;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            // Get input (WASD or Arrow Keys)
            float h = Input.GetAxis("Horizontal"); 
            float v = Input.GetAxis("Vertical");   

            // Move relative to world axes (X,Z)
            Vector3 move = new Vector3(h, 0f, v);

            // Normalize to prevent faster diagonal movement
            if (move.magnitude > 0.1f)
            {
                // Rotate player toward movement direction
                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, targetAngle, 0), Time.deltaTime * 10f);
            }

            // Apply movement
            controller.Move(move * moveSpeed * Time.deltaTime);
        }
    }
}
