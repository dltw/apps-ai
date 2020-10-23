using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 1.0f; // positive = toward, negative = away
    public Vector2 targetPosition = Vector2.zero;

    void Start()
    {

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
    }
}
