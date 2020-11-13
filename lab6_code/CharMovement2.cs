using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement2 : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    bool playerGrounded;
    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;
    public float jumpHeight = 3.0f;
    float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float axisH = Input.GetAxis("Horizontal"); // Keys A, D, left, right
        float axisV = Input.GetAxis("Vertical"); // Keys W, S, up, down
        float currentSpeed = axisV * speed * Time.deltaTime;
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        transform.Rotate(0, axisH * rotateSpeed, 0);

        playerGrounded = controller.isGrounded;
        if (playerGrounded && velocity.y < 0.0f)
        {
            velocity.y = 0.0f; // lock to y-axis origin
        }

        controller.Move(forwardDirection * currentSpeed);

        if (Input.GetButtonDown("Jump")) // Keys spacebar
        {
            velocity.y += Mathf.Sqrt(Mathf.Abs(-jumpHeight * gravity)); // jump
        }

        velocity.y += gravity * Time.deltaTime; // fall
        controller.Move(velocity * Time.deltaTime);
    }
}
