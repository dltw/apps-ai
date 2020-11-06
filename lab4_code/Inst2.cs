using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inst2 : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-8f, 8f),
                0.0f,
                Random.Range(-8f, 8f)
            );

            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
