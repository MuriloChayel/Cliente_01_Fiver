using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;
    public bool alive = true;
    public bool inGame;
    public float jumpForce, cooldown;


    [SerializeField]float tAtual;

    public int score;
    [SerializeField] GManager manager;

    [SerializeField] TMP_Text scorePoints;

    public AudioClip[] soundEffects;
    public AudioSource audioController;
    public AudioSource coinEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        tAtual = Time.time;
    }
    private void Update()
    {
        if (alive && inGame)
        {
            if (Time.time - tAtual > cooldown)
            {
                an.Play("flapDown");
            }
            bool press = Input.GetMouseButtonDown(0);
            if (press)
            {
                Flap();
            }
        }
    }   
    public void Flap()
    {
        tAtual = Time.time;
        rb.velocity = Vector2.up * jumpForce;
        SoundEffectController(0);
        an.Play("flapUp");   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            score++;
            coinEffect.Play();
        }
        manager.RestartLevel(score + "");
        scorePoints.text = "" + score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            manager.GetComponent<HighScore>().SetHighScore(score);
            GetComponent<PlayerBehaviour>().alive = false;
            SoundEffectController(1);   
            manager.GameOver();
        }
    }
    public void SoundEffectController(int id)
    {
        if(id < soundEffects.Length)
            audioController.clip = soundEffects[id];
        audioController.Play();
    }
}