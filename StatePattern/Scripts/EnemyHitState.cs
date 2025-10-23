using UnityEngine;

namespace StatePattern
{
    public class EnemyHitState : EnemyState
    {
        private float attackDuration = 1.0f;
        private float timer;

        public EnemyHitState(EnemyController enemy, EnemyStateMachine stateMachine)
            : base(enemy, stateMachine) { }

        public override void Enter()
        {
            Debug.Log("Enemy: Attacking Player!");
            enemy.DealDamageToPlayer(); // Apply damage
            timer = attackDuration;
        }

        public override void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                float distance = Vector3.Distance(enemy.transform.position, enemy.player.position);

                if (distance <= enemy.attackRange)
                    stateMachine.ChangeState(new EnemyHitState(enemy, stateMachine)); // keep attacking
                else if (distance < enemy.followRange)
                    stateMachine.ChangeState(new EnemyFollowState(enemy, stateMachine));
                else
                    stateMachine.ChangeState(new EnemyPatrolState(enemy, stateMachine));
            }
        }

        public override void Exit() { }
    }
}
