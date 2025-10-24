using UnityEngine;

public class BossEnemy : IEnemy
{
    public void Attack()
    {
        Debug.Log("Boss Enemy fight with the player!");
    }
}
