using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    private StateManager stateManager;

    private void OnTriggerEnter(Collider other)
    {
        stateManager.NextState();
    }
}
