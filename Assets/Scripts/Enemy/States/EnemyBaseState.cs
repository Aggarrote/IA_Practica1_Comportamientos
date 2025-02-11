using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateController enemy);

    public abstract void UpdateState(EnemyStateController enemy);

    public abstract void OnAudioDetectState(EnemyStateController enemy, Vector3 soundPosition);

    public abstract void OnVisionDetectState(EnemyStateController enemy, Vector3 lastSeenPosition);

    public abstract void OnVisionNotDetectState(EnemyStateController enemy);
}
