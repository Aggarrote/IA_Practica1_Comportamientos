using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float normalSpeed = 10, rotationSpeed = 10;
    float speed;
    bool running = false;
    StepManager myStepManager;

    void Start()
    {
        speed = normalSpeed;
        myStepManager = GetComponent<StepManager>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = normalSpeed * 1.5f;
            running = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
            running = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            myStepManager.StopCounting();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            myStepManager.StopCounting();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            myStepManager.StartCounting();
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            myStepManager.StartCounting();
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        this.transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.Self);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * -rotationSpeed);
        }
    }

    public bool GetRunning()
    {
        return running;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("RinthLaberinth");
        }
    }
}
