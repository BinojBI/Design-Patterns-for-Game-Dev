using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(EnemyController enemy, EnemyStateMachine stateMachine)
        : base(enemy, stateMachine) { }
    public override void Enter() { }

    public override void Update() { }

    public override void Exit() { }
}
