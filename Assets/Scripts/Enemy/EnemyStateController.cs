using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyActState ActState = new EnemyActState();
    public EnemyPercieveState PercieveState = new EnemyPercieveState();
    public EnemyThinkState ThinkState = new EnemyThinkState();

    void Start()
    {
        currentState = ThinkState; //Hace que el proximo estado sea el primer estado necesario
        
        currentState.EnterState(this); //Activa el metodo EnterState para que cambie a ese estado
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this); //si queremos tambi�n a�adir la collision habr�a que cambiarlo aqu� por (this, collision), y en la funci�n (EnemyStateController enemy, Collision collision)
    }

    public void ChangeState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
