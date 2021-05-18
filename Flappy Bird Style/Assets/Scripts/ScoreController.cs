using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score;
    public bool alive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score")) 
            score++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
            alive = false;
    }
}
