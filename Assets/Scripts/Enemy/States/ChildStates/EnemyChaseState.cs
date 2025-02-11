using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    bool seeingPlayer = false;
    Vector3 lastSeenPosition, soundPosition;

    public override void EnterState(EnemyStateController enemy)
    {
        enemy.hat.material = enemy.hatMaterials[1];
        lastSeenPosition = enemy.lastPlayerPosition;
        soundPosition = enemy.lastPlayerPosition;
    }

    public override void UpdateState(EnemyStateController enemy)
    {
        if (seeingPlayer)
        {
            enemy.myMovement.FollowPlayer(lastSeenPosition);
        }

        else
        {
            enemy.myMovement.FollowPlayer(soundPosition);
        }

        if (Vector3.Distance(enemy.transform.position, enemy.lastPlayerPosition) <= enemy.safeDistance/2 || Vector3.Distance(enemy.transform.position, enemy.lastPlayerPosition) >= -enemy.safeDistance/2) //Si se encuentra dentro de la zona segura de la ultima posicion conocida
        {
            enemy.ChangeState(enemy.searchState);
        }
    }

    public override void OnAudioDetectState(EnemyStateController enemy, Vector3 _soundPosition)
    {
        soundPosition = _soundPosition;

        if (!seeingPlayer)
        {
            enemy.lastPlayerPosition = soundPosition;
        }
    }

    public override void OnVisionDetectState(EnemyStateController enemy, Vector3 _lastSeenPosition)
    {
        seeingPlayer = true;
        lastSeenPosition = _lastSeenPosition;
        enemy.lastPlayerPosition = lastSeenPosition;
    }

    public override void OnVisionNotDetectState(EnemyStateController enemy)
    {
        seeingPlayer = false;
    }
}
