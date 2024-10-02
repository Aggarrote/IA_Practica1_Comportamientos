using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement_Rotation();
    }

    void Movement_Rotation()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W))
        {
            Movement();
        }
    }
  
    void Movement()
    {
       
    }
}
