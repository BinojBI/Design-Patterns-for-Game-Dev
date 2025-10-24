using UnityEngine;
using static EnemyFactory;

public class EnemySpawner : MonoBehaviour
{
    private void Start()
    {
        IEnemy melee = EnemyFactory.CreateEnemy(EnemyType.Melee);
        IEnemy ranged = EnemyFactory.CreateEnemy(EnemyType.Ranged);
        IEnemy boss = EnemyFactory.CreateEnemy(EnemyType.Boss);

        melee.Attack();
        ranged.Attack();
        boss.Attack();

    }
}
