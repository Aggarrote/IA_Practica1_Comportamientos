using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyMovement : MonoBehaviour
{
    protected float speed = 20;
    [SerializeField] protected Transform[] movementPoints;
    [SerializeField] protected float minimumDistance;
    protected NavMeshAgent agent;
    protected bool followingPoints = true;
    protected Vector3 playerPosition;

    public void FollowPlayer(Vector3 _playerPosition)
    {
        playerPosition = _playerPosition;
        followingPoints = false;
    }

    public abstract void RouteStart();
}
