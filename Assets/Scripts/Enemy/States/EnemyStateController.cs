using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateController : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemySearchState searchState = new EnemySearchState();
    public EnemyPatrolState patrollState = new EnemyPatrolState();
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemyMovement myMovement;
    public Vector3 lastPlayerPosition;
    public float safeDistance = 0.3f;

    public Material [] hatMaterials;
    public MeshRenderer hat;

    void Start()
    {
        myMovement = GetComponent<EnemyMovement>();

        currentState = patrollState;       
        currentState.EnterState(this); 
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void OnAudioDetect(Vector3 position)
    {
        currentState.OnAudioDetectState(this, position);
    }

    public void OnVisionDetect(Vector3 position)
    {
        currentState.OnVisionDetectState(this, position);
    }

    public void OnVisionNotDetect()
    {
        currentState.OnVisionNotDetectState(this);
    }

    public void ChangeState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
