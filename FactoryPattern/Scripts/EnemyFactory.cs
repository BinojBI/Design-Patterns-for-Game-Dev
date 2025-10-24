using UnityEngine;

public static class EnemyFactory
{
    public enum EnemyType
    {
        Melee,
        Ranged,
        Boss
    }

    public static IEnemy CreateEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Melee:
                return new MeleeEnemy();
            case EnemyType.Ranged:
                return new RangedEnemy();
            case EnemyType.Boss:
                return new BossEnemy();
            default:
                Debug.LogError("Unknown enemy type!");
                return null;
        }
    }

}
