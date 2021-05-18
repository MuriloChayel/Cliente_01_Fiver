using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryBehaviour : MonoBehaviour
{
    [Range(1,10)]
    public float velocity, destroyDelay;


    private void FixedUpdate()
    {
        Move();
        Destroy(gameObject, destroyDelay);
    }
    private void Move()
    {
        transform.Translate(velocity * Vector2.left * Time.fixedDeltaTime);
    }
  
}
