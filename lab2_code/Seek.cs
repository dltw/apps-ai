using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target;
    public float speed = 3.0f;
    private Vector3 targetPosition;

    void Start()
    {
        
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        targetPosition = target.position;
        targetPosition.y = 0.0f;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
