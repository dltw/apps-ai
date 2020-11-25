using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Variables
    public float velocity = 5.0f;
    public Vector3 targetPosition = Vector2.zero;
    private State currentState;
    public float timeRemaining;
    private const float timeDelay = 10.0f;

    private enum State
    {
        Idle = 0,
        PatrolZone11 = 1,
        PatrolZone10 = 2,
        PatrolZone01 = 3,
        PatrolZone00 = 4,
    }

    // Zone coordinates
    Vector3 Home = new Vector3(0.0f, 0.5f, 0.0f);
    Vector3 Zone11 = new Vector3(3.0f, 0.5f, 3.0f);
    Vector3 Zone10 = new Vector3(3.0f, 0.5f, -3.0f);
    Vector3 Zone01 = new Vector3(-3.0f, 0.5f, 3.0f);
    Vector3 Zone00 = new Vector3(-3.0f, 0.5f, -3.0f);


    // Methods
    public Vector3 NextState()
    {
        currentState += 1; // move to next state
        if (currentState > State.PatrolZone00)
        {
            currentState = State.Idle;
        }

        switch (currentState)
        {
            case State.Idle:
                targetPosition = Home;
                Debug.Log("Home");
                break;
            case State.PatrolZone11:
                targetPosition = Zone11;
                Debug.Log("Zone11");
                break;
            case State.PatrolZone10:
                targetPosition = Zone10;
                Debug.Log("Zone10");
                break;
            case State.PatrolZone01:
                targetPosition = Zone01;
                Debug.Log("Zone01");
                break;
            case State.PatrolZone00:
                targetPosition = Zone00;
                Debug.Log("Zone00");
                break;
            default:
                targetPosition = Home;
                Debug.Log("Error - Going Home");
                break;
        }

        return targetPosition;
    }

    void Start()
    {
        // initialise variables
        currentState = State.Idle;
        targetPosition = Home;
        timeRemaining = timeDelay;
    }

    void Update()
    {
        float step = velocity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeRemaining = timeDelay; // reset timer
            NextState(); // manually change to next state
            Debug.Log("Spacebar pressed");
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = timeDelay; // reset timer
            NextState();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
