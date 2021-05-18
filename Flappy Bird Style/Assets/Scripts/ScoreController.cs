using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{
    public int score;
    public bool alive;
    [SerializeField] GManager manager;

    [SerializeField] TMP_Text scorePoints;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score")) 
            score++;
        manager.RestartLevel(score + "");
        scorePoints.text = "" + score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            alive = false;
            manager.GameOver();
        }

    }
}
