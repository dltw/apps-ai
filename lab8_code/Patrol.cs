using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] wayPointArray;
    private NavMeshAgent agent;
    int index = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        AgentPatrol();
    }

    void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 1.5f)
        {
            AgentPatrol();
        }
    }

    void AgentPatrol()
    {
        if (wayPointArray.Length == 0)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }

        agent.destination = wayPointArray[index].position;
        index++;
        if (index >= wayPointArray.Length)
        {
            index = 0;
        }
    }
}