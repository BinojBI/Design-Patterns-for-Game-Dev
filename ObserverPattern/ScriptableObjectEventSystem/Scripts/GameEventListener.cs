using UnityEngine;
using UnityEngine.Events;

namespace ScritptbaleObjectEventSystem
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable() => gameEvent.Register(this);
        private void OnDisable() => gameEvent.Unregister(this);

        public void OnEventRaised() => response.Invoke();
    }
}
