using UnityEngine;

namespace ScritptbaleObjectEventSystem
{
    public class PlayerController : MonoBehaviour
    {
        public GameEvent onPlayerJumped;
        public float jumpForce = 5f;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                onPlayerJumped?.Raise(); // Broadcast the event
            }
        }

        void Jump()
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
