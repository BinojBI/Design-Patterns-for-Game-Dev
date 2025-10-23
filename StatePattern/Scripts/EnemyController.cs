using UnityEngine;

namespace StatePattern
{
    public class EnemyController : MonoBehaviour
    {
        public Transform[] patrolPoints;
        public Transform player;
        public float moveSpeed = 2f;
        public float followRange = 5f;
        public float attackRange = 1.5f;
        public int health = 3;

        [HideInInspector] public EnemyStateMachine stateMachine;

        private void Start()
        {
            stateMachine = new EnemyStateMachine();

            var patrolState = new EnemyPatrolState(this, stateMachine);
            stateMachine.Initialize(patrolState);
        }

        private void Update()
        {
            stateMachine.Update();

        }

        public void TakeDamage()
        {
            if (health <= 0)
                return;

            health--;
            if (health > 0)
                stateMachine.ChangeState(new EnemyHitState(this, stateMachine));
            else
                stateMachine.ChangeState(new EnemyDieState(this, stateMachine));
        }
        public void DealDamageToPlayer()
        {
            Debug.Log("Enemy hit the player!");
        }
    }
}
