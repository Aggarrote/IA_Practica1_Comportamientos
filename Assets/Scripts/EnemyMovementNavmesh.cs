using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementNavmesh : MonoBehaviour
{
    float velocidad = 20;
    [SerializeField] Transform[] puntosMovimiento;
    [SerializeField] float distanciaMin;
    int numAleatorio, numeroPuntoNormal;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = velocidad;
        agent.stoppingDistance = 3;
        numAleatorio = Random.Range(0, puntosMovimiento.Length);
        numeroPuntoNormal = 0;
        agent.SetDestination(puntosMovimiento[numAleatorio].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, puntosMovimiento[numAleatorio].position) <= distanciaMin)
        {
            Debug.Log("Estoy cambiando de objetivo");
            numAleatorio = Random.Range(0, puntosMovimiento.Length);
            agent.SetDestination(puntosMovimiento[numAleatorio].position);
        }
    }

    //float velocidad = 20;
    //[SerializeField] Transform[] puntosMovimiento;
    //[SerializeField] float distanciaMin;
    //int siguientePunto = 0;
    //NavMeshAgent agent;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    agent.speed = velocidad;
    //    agent.stoppingDistance = 3;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    agent.SetDestination(puntosMovimiento[siguientePunto].position);
    //    if (Vector3.Distance(transform.position, puntosMovimiento[siguientePunto].position) <= distanciaMin)
    //    {
    //        siguientePunto += 1;
    //        if(siguientePunto >= puntosMovimiento.Length)
    //        {
    //            siguientePunto = 0;
    //        }
    //    }
    //}
}

