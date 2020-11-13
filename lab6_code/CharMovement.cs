using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    CharacterController controller;
    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float axisH = Input.GetAxis("Horizontal"); // Keys A, D, left, right
        float axisV = Input.GetAxis("Vertical"); // Keys W, S, up, down
        float currentSpeed = axisV * speed;

        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        transform.Rotate(0, axisH * rotateSpeed, 0);

        controller.SimpleMove(forwardDirection * currentSpeed);
    }
}