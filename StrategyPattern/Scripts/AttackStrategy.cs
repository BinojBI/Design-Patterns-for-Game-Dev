using UnityEngine;

namespace StrategyPattern
{
    public class MeleeAttack : IAttackStrategy
    {
        public void Attack(Transform enemyTransform, Transform playerTransform)
        {
            Debug.Log("Enemy performs a melee attack!");
            // Example: Move slightly toward player
            enemyTransform.LookAt(playerTransform);
        }
    }

    public class RangedAttack : IAttackStrategy
    {
        public void Attack(Transform enemyTransform, Transform playerTransform)
        {
            Debug.Log("Enemy fires a ranged projectile!");
            // Example: instantiate a bullet here
        }
    }

    public class MagicAttack : IAttackStrategy
    {
        public void Attack(Transform enemyTransform, Transform playerTransform)
        {
            Debug.Log("Enemy casts a magic spell!");
            // Example: play VFX here
        }
    }
}
