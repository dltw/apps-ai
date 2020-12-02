using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 target;
    public float speed = 5.0f;
    public float jumpHeight = 7.0f;
    public Vector2 maxVelocity = new Vector2(0f, 0.35f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        target = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            target += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            target += Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            target += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            target += Vector2.down;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.magnitude < maxVelocity.magnitude)
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }

        if (transform.position.y < -10f)
        {
            FindObjectOfType<GameManager>().EndGame();
            //Debug.Log("Object fall");
        }

        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
