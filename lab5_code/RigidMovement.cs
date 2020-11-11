using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float applyForce = 1500f;
    public float dampingForce = 0.15f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-applyForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(applyForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, applyForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -applyForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * dampingForce, ForceMode.Impulse);
        }
    }
}
