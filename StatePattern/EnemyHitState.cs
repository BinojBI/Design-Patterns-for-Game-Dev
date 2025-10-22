using UnityEngine;

public class EnemyHitState : EnemyState
{
    private float attackDuration = 1.0f;
    private float timer;

    public EnemyHitState(EnemyController enemy, EnemyStateMachine stateMachine)
        : base(enemy, stateMachine) { }

    public override void Enter() {
        Debug.Log("Enemy: Attacking Player!");
        enemy.DealDamageToPlayer(); // Apply damage
        timer = attackDuration;
    }

    public override void Update() { }

    public override void Exit() { }
}
