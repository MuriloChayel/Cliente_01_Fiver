using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{
    public float velocity;
    Vector3 startPosition;
    public float limit; 
    private void Start()
    {
        startPosition = transform.position;
    }
    private void FixedUpdate()
    {
       
        Move();
    }
    void Move()
    {
        transform.Translate(Vector2.left * velocity * Time.deltaTime);
        if (transform.position.x <= limit)
            transform.position = startPosition;
    }
}
