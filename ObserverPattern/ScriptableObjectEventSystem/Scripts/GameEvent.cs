using System.Collections.Generic;
using UnityEngine;

namespace ScritptbaleObjectEventSystem
{

    [CreateAssetMenu(fileName = "PlayerEvent", menuName = "Scriptable Objects/PlayerEvent")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new();

        public void Raise()
        {
            foreach (var listener in listeners)
                listener.OnEventRaised();
        }

        public void Register(GameEventListener listener) => listeners.Add(listener);
        public void Unregister(GameEventListener listener) => listeners.Remove(listener);
    }
}
