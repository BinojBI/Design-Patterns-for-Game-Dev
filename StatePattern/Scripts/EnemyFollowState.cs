using UnityEngine;

namespace StatePattern
{
    public class EnemyFollowState : EnemyState
    {
        public EnemyFollowState(EnemyController enemy, EnemyStateMachine stateMachine)
            : base(enemy, stateMachine) { }
        public override void Enter()
        {
            Debug.Log("Enemy: Start Following Player");
        }

        public override void Update()
        {
            if (enemy.player == null) return;

            enemy.transform.position = Vector3.MoveTowards(
                enemy.transform.position,
                enemy.player.position,
                enemy.moveSpeed * Time.deltaTime
            );

            float distance = Vector3.Distance(enemy.transform.position, enemy.player.position);

            if (distance > enemy.followRange)
            {
                stateMachine.ChangeState(new EnemyPatrolState(enemy, stateMachine));
            }
            else if (distance <= enemy.attackRange)
            {
                stateMachine.ChangeState(new EnemyHitState(enemy, stateMachine));
            }
        }

        public override void Exit()
        {
            Debug.Log("Enemy: Stop Following Player");
        }
    }
}
