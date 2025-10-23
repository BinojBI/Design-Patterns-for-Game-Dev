using UnityEngine;

namespace StatePattern
{
    public class EnemyPatrolState : EnemyState
    {
        private int currentPoint = 0;

        public EnemyPatrolState(EnemyController enemy, EnemyStateMachine stateMachine)
            : base(enemy, stateMachine) { }
        public override void Enter()
        {
            Debug.Log("Enemy: Start Patrolling");
        }

        public override void Update()
        {
            if (enemy.patrolPoints.Length == 0) return;

            Transform targetPoint = enemy.patrolPoints[currentPoint];
            enemy.transform.position = Vector3.MoveTowards(
                enemy.transform.position,
                targetPoint.position,
                enemy.moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(enemy.transform.position, targetPoint.position) < 0.1f)
            {
                currentPoint = (currentPoint + 1) % enemy.patrolPoints.Length;
            }

            if (Vector3.Distance(enemy.transform.position, enemy.player.position) < enemy.followRange)
            {
                stateMachine.ChangeState(new EnemyFollowState(enemy, stateMachine));
            }


        }

        public override void Exit()
        {
            Debug.Log("Enemy: Stop Patrolling");
        }
    }
}
