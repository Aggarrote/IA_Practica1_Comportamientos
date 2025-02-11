using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    public override void EnterState(EnemyStateController enemy)
    {
        enemy.hat.material = enemy.hatMaterials[0];
        enemy.myMovement.RouteStart();
    }

    public override void UpdateState(EnemyStateController enemy)
    {

    }

    public override void OnAudioDetectState(EnemyStateController enemy, Vector3 soundPosition)
    {
        enemy.lastPlayerPosition = soundPosition;
        enemy.ChangeState(enemy.chaseState);
    }

    public override void OnVisionDetectState(EnemyStateController enemy, Vector3 lastSeenPosition)
    {
        enemy.lastPlayerPosition = lastSeenPosition;
        enemy.ChangeState(enemy.chaseState);
    }

    public override void OnVisionNotDetectState(EnemyStateController enemy)
    {
        
    }
}
