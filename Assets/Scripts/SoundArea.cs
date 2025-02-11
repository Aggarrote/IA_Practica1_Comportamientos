using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundArea : MonoBehaviour
{
    [SerializeField] float maxSpeed, minSpeed;
    float scale = 0.001f, soundSpeed = 355, maxScale;
    Vector3 scaleVector;

    void Start()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetRunning())
        {
            soundSpeed = maxSpeed;
            maxScale = 7;
        }

        else
        {
            soundSpeed = minSpeed;
            maxScale = 3;
        }

        scaleVector = new Vector3(scale, 1, scale);
    }

    void Update()
    {
        if (scale > maxScale)
        {
            Destroy(this.gameObject);
        }

        transform.localScale = scaleVector;
        scale += Time.deltaTime * soundSpeed;
        scaleVector.x = scale;
        scaleVector.z = scale;
    }
}
