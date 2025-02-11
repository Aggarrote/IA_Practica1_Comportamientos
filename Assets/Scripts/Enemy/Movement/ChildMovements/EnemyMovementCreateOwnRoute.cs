using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementCreateOwnRoute : EnemyMovement
{
    int nextPoint = 0;
    [SerializeField] int numMovePointsToUse = 5;
    Transform[] movementPointsToUse;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = 1;

        if (numMovePointsToUse > movementPoints.Length)
        {
            numMovePointsToUse = movementPoints.Length;
        }

        movementPointsToUse = new Transform[numMovePointsToUse];
        CreationPointsToUse();
    }

    void Update()
    {
        if (followingPoints)
        {
            agent.SetDestination(movementPointsToUse[nextPoint].position);

            if (Vector3.Distance(transform.position, movementPointsToUse[nextPoint].position) <= minimumDistance)
            {
                nextPoint++;

                if (nextPoint >= movementPointsToUse.Length)
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

    void CreationPointsToUse()
    {
        for (int i = 0; i < numMovePointsToUse; i++)
        {
            bool notRepeated;

            do
            {
                notRepeated = true;
                movementPointsToUse[i] = movementPoints[Random.Range(0, movementPoints.Length)];

                for (int j = 0; j < i; j++)
                {
                    if (movementPointsToUse[i] == movementPointsToUse[j])
                    {
                        notRepeated = false;
                        break;
                    }
                }
            } while (!notRepeated);
        }
    }

    public override void RouteStart()
    {
        CreationPointsToUse();
        followingPoints = true;
    }
}
