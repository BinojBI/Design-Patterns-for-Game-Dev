using UnityEngine;

public class RangedEnemy : IEnemy
{
    public void Attack()
    {
        Debug.Log("Ranged Enemy attack the player!");
    }
}
