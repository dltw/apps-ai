using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inst3 : MonoBehaviour
{
    public GameObject prefab;
    public int height = 3;
    public int width = 8;
    public Vector3 location = Vector3.zero;

    void Start()
    {
        location.z = 0.0f;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Instantiate(prefab, new Vector3(
                    x + (int)location.x,
                    y + (int)location.y,
                    0.0f),
                    Quaternion.identity);
            }
        }
    }

    void Update()
    {
        
    }
}
