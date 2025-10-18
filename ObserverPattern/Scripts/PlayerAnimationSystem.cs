using UnityEngine;

public class PlayerAnimationSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject playerSubject;
    public void OnNotify(PlayerBehaviour behavior)
    {
        if(behavior == PlayerBehaviour.Jump)
        {
            Debug.Log("player jump animation works");
        }
    }

    private void OnEnable()
    {
        playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        playerSubject.RemoveObserver(this);
    }

}
