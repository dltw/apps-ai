using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float maxVelocity = 1.0f;
    public float Mass = 1.0f;
    public float Friction = 0.05f;
    public Vector2 Acceleration = Vector2.zero;
    [HideInInspector] public Vector2 currentVelocity;
    public Vector2 targetPosition = Vector2.zero;
    
    private void Start()
    {
        
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, (Vector3)targetPosition);
        Vector2 desiredVelocity = (targetPosition - (Vector2)transform.position).normalized;

        desiredVelocity = desiredVelocity * maxVelocity;
        currentVelocity = desiredVelocity - currentVelocity;

        currentVelocity += Acceleration / Mass;
        currentVelocity -= currentVelocity * Friction;

        if (currentVelocity.magnitude > maxVelocity)
            currentVelocity = currentVelocity.normalized * maxVelocity; // truncate currentVelocity

        if (distance <= 0.01f)
        {
            desiredVelocity = Vector2.zero;
        }
        else
        {
            transform.position = transform.position + (Vector3)currentVelocity * Time.deltaTime;
        }
    }
}
