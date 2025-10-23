using UnityEngine;

namespace StatePattern
{
    public class EnemyDieState : EnemyState
    {
        public EnemyDieState(EnemyController enemy, EnemyStateMachine stateMachine)
            : base(enemy, stateMachine) { }
        public override void Enter()
        {
            Debug.Log("Enemy: Died");
            GameObject.Destroy(enemy.gameObject, 1f);
        }

        public override void Update() { }

        public override void Exit() { }
    }
}
