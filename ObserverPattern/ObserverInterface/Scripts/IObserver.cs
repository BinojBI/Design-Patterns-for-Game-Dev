using UnityEngine;

namespace ObserverInterface
{
    public interface IObserver
    {
        public void OnNotify(PlayerBehaviour behavior);
    }
}