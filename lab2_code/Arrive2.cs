using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive2 : MonoBehaviour
{
    public float speed = 10f;
    public float stopRadius = 0.2f;
    public float slowRadius = 5.0f;
    private Vector3 targetPosition;
    private Vector3 position = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, targetPosition);
        RaycastHit raycastHitData;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out raycastHitData, 1000f))
        {
            position = raycastHitData.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = position;
            //Debug.Log(position);
        }

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
