using UnityEngine;

namespace ObserverInterface
{
    public class PlayerController : Subject
    {
        private void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NotifyObservers(PlayerBehaviour.Jump);
            }
        }
    }
}
