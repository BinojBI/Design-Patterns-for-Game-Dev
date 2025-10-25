using UnityEngine;
using System.Collections;

namespace StatePattern
{
    public class EnemyHitState : EnemyState
    {
        private float attackDuration = 1.0f;
        private float timer;
        private MonoBehaviour coroutineHost;

        public EnemyHitState(EnemyController enemy, EnemyStateMachine stateMachine)
            : base(enemy, stateMachine) {
            coroutineHost = enemy;
        }

        public override void Enter()
        {
            Debug.Log("Enemy: Attacking Player!");
            enemy.DealDamageToPlayer(); // Apply damage
            coroutineHost.StartCoroutine(RotateOnce(attackDuration));
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

        private IEnumerator RotateOnce(float duration)
        {
            float elapsed = 0f;
            float startRotation = enemy.transform.eulerAngles.y;
            float endRotation = startRotation + 360f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float currentY = Mathf.Lerp(startRotation, endRotation, elapsed / duration);
                enemy.transform.rotation = Quaternion.Euler(0f, currentY, 0f);
                yield return null;
            }

            enemy.transform.rotation = Quaternion.Euler(0f, endRotation, 0f);
        }

        public override void Exit() { }
    }
}
