using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    public float speed = 3.0f;
    public float stopRadius = 0.2f;
    public float slowRadius = 5.0f;
    public Vector3 targetPosition = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, targetPosition);
        targetPosition.y = 0.0f;

        if (distance < stopRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.0f);
        }
        else if (distance < slowRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step * (distance - stopRadius) / (slowRadius - stopRadius));
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
}
