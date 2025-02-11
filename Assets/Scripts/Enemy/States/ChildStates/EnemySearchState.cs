using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : EnemyBaseState
{
    float speedAngle = 30, anglesRotated, anglesPerSecond;
    public override void EnterState(EnemyStateController enemy)
    {
        enemy.hat.material = enemy.hatMaterials[2];
    }

    public override void UpdateState(EnemyStateController enemy)
    {
        anglesPerSecond = speedAngle * Time.deltaTime;
        enemy.transform.Rotate(Vector3.up, anglesPerSecond);
        anglesRotated += anglesPerSecond;

        if (anglesRotated > 360) 
        {
            anglesRotated = 0;
            enemy.ChangeState(enemy.patrollState);
        }
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
