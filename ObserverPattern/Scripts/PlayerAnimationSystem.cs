using UnityEngine;

public class PlayerAnimationSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject playerSubject;
    [SerializeField]  private Animator playerAnimator;
    public void OnNotify(PlayerBehaviour behavior)
    {
        if(behavior == PlayerBehaviour.Jump)
        {
            Debug.Log("player jump animation works");
            playerAnimator.SetTrigger("jump");
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
