using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLab : MonoBehaviour
{
    EnemyStateController myStateMachine;

    private void Start()
    {
        myStateMachine = GetComponent<EnemyStateController>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Sound")
        {
            myStateMachine.OnAudioDetect(collision.transform.position);
        }
    }
}
