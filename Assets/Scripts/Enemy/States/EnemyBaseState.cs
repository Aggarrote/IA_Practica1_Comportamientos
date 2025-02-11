using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateController enemy);

    public abstract void UpdateState(EnemyStateController enemy);

    public abstract void OnCollisionEnter(EnemyStateController enemy);
}
