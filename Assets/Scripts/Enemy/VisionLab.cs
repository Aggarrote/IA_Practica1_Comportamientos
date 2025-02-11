using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VisionLab : MonoBehaviour
{
    [SerializeField] float visionDistance = 30, maxAngle = 15;
    [SerializeField] int numbRaysBetween = 2;
    Vector3 position;
    Vector3 maxLeft, center, maxRight, betweenVector;
    [SerializeField] Color rayColor = Color.red;

    [SerializeField] Transform pointOfView;

    EnemyStateController myStateMachine;

    private void Start()
    {
        myStateMachine = GetComponent<EnemyStateController>();
    }

    void FixedUpdate()
    {
        center = transform.forward;
        maxLeft = Quaternion.AngleAxis(-maxAngle, transform.up) * center;
        maxRight = Quaternion.AngleAxis(maxAngle, transform.up) * center;
        position = pointOfView.transform.position;

        DrawDebugRays();
        LookArea();
    }

    void DrawDebugRays()
    {
        //MAX_LEFT
        Debug.DrawRay(position, maxLeft * visionDistance, rayColor);

        //LEFT_BETWEEN
        for (int i = 1; i <= numbRaysBetween; i++)
        {
            betweenVector = Quaternion.AngleAxis(-maxAngle + (maxAngle / (numbRaysBetween + 1)) * i, transform.up) * center; //Hay que sumar uno a numbRaysBetween para que no empiece en 0, evitando dibujar el centro
            Debug.DrawRay(position, betweenVector * visionDistance, rayColor);
        }

        //CENTER
        Debug.DrawRay(position, center * visionDistance, rayColor);

        //RIGHT_BETWEEN
        for (int i = 1; i <= numbRaysBetween; i++)
        {
            betweenVector = Quaternion.AngleAxis(maxAngle - (maxAngle / (numbRaysBetween + 1)) * i, transform.up) * center; //Hay que sumar uno a numbRaysBetween para que no empiece en 0, evitando dibujar el centro
            Debug.DrawRay(position, betweenVector * visionDistance, rayColor);
        }

        //MAX_RIGHT
        Debug.DrawRay(position, maxRight * visionDistance, rayColor);
    }

    void LookArea()
    {
        RaycastHit hit;

        //LEFT
        if (Physics.Raycast(position, maxLeft * visionDistance, out hit) && DetectingPlayer(hit))
        {
            Debug.DrawRay(position, maxLeft * visionDistance, Color.green);
            LetEnemyKnowHeSaw(hit);
            return;
        }

        for (int i = 1; i <= numbRaysBetween; i++)
        {
            betweenVector = Quaternion.AngleAxis(-maxAngle + (maxAngle / (numbRaysBetween + 1)) * i, transform.up) * center; //Hay que sumar uno a numbRaysBetween para que no empiece en 0, evitando dibujar el centro

            if (Physics.Raycast(position, betweenVector * visionDistance, out hit) && DetectingPlayer(hit))
            {
                Debug.DrawRay(position, betweenVector * visionDistance, Color.green);
                LetEnemyKnowHeSaw(hit);
                return;
            }
        }

        //CENTER
        if (Physics.Raycast(position, center * visionDistance, out hit) && DetectingPlayer(hit))
        {
            Debug.DrawRay(position, center * visionDistance, Color.green);
            LetEnemyKnowHeSaw(hit);
            return;
        }

        //RIGHT
        for (int i = 1; i <= numbRaysBetween; i++)
        {
            betweenVector = Quaternion.AngleAxis(maxAngle - (maxAngle / (numbRaysBetween + 1)) * i, transform.up) * center; //Hay que sumar uno a numbRaysBetween para que no empiece en 0, evitando dibujar el centro

            if (Physics.Raycast(position, betweenVector * visionDistance, out hit) && DetectingPlayer(hit))
            {
                Debug.DrawRay(position, betweenVector * visionDistance, Color.green);
                LetEnemyKnowHeSaw(hit);
                return;
            }
        }

        if (Physics.Raycast(position, maxRight * visionDistance, out hit) && DetectingPlayer(hit))
        {
            Debug.DrawRay(position, maxRight * visionDistance, Color.green);
            LetEnemyKnowHeSaw(hit);
            return;
        }

        LetEnemyKnowHeDoesntSee();
        return;
    }

    bool DetectingPlayer(RaycastHit hit)
    {
        if (hit.transform.GetComponent<PlayerMovement>() != null)
        {
            return true;
        }

        return false;
    }

    void LetEnemyKnowHeSaw(RaycastHit hit)
    {
        myStateMachine.OnVisionDetect(hit.transform.position);
    }

    void LetEnemyKnowHeDoesntSee()
    {
        myStateMachine.OnVisionNotDetect();
    }
}