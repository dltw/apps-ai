using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jewel"))
        {
            FindObjectOfType<Score>().AddScore();
            Destroy(collision.gameObject);
        }
    }
}
