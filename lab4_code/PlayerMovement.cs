using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        target = transform.position; // 8-ways direction

        if (Input.GetKey(KeyCode.A))
        {
            target += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            target += Vector3.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            target += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            target += Vector3.back;
        }

        target.y = 0.0f;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
