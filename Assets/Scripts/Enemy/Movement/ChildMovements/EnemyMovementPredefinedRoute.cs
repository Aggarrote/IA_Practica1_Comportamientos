using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementPredefinedRoute : EnemyMovement
{
    int nextPoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = 1;
    }

    void Update()
    {
        if (followingPoints)
        {
            agent.SetDestination(movementPoints[nextPoint].position);

            if (Vector3.Distance(transform.position, movementPoints[nextPoint].position) <= minimumDistance)
            {
                nextPoint++;

                if (nextPoint >= movementPoints.Length)
                {
                    nextPoint = 0;
                }
            }
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
