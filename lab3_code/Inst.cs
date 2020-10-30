using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inst : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(prefab, new Vector3(i * 2.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
