using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementRandomRoute : EnemyMovement
{
    int randomNumber;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = 1;
        randomNumber = Random.Range(0, movementPoints.Length);
        agent.SetDestination(movementPoints[randomNumber].position);
    }

    void Update()
    {       
        if (followingPoints) 
        {
            if (Vector3.Distance(transform.position, movementPoints[randomNumber].position) <= minimumDistance)
            {
                randomNumber = Random.Range(0, movementPoints.Length);
            }
            agent.SetDestination(movementPoints[randomNumber].position);
        }

        else if (!followingPoints)
        {
            agent.SetDestination(playerPosition);
        }
    }

    public override void RouteStart()
    {
        followingPoints = true;
    }
}
