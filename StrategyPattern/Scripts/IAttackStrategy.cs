using UnityEngine;

namespace StrategyPattern
{
    public interface IAttackStrategy
    {
        void Attack(Transform enemyTransform, Transform playerTransform);
    }

}
