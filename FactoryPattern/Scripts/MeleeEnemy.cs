using UnityEngine;

public class MeleeEnemy : IEnemy
{
    public void Attack()
    {
        Debug.Log("Melee Enemy slashes the player!");
    }
}
