using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThinkState : EnemyBaseState
{
    public override void EnterState(EnemyStateController enemy)
    {
        Debug.Log("Estoy en el estado Think");
    }

    public override void UpdateState(EnemyStateController enemy)
    {
        if (true)
        {

        }

        else
        {
            enemy.ChangeState(enemy.ActState);
        }
    }

    public override void OnCollisionEnter(EnemyStateController enemy)
    {

    }
}
