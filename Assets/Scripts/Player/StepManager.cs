using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    [SerializeField] GameObject soundArea;
    float countDown;
    [SerializeField] float maxTimer = 0.5f;
    bool canCount = false;

    void Update()
    {
        if (canCount)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }

            else
            {
                Instantiate(soundArea, transform.position, Quaternion.identity);
                countDown = maxTimer;
            }
        }
    }

    public void StartCounting()
    {
        canCount = true;
        countDown = 0;
    }

    public void StopCounting()
    {
        canCount = false;
        countDown = maxTimer;
    }
}
