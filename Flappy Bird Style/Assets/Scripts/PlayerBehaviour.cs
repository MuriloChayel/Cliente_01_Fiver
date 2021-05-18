using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;
    public bool alive = true;
    public float jumpForce,cooldown;


    [SerializeField]float tAtual;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        tAtual = Time.time;
    }


    private void Update()
    {
        if (!alive)
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
    void Flap()
    {
        tAtual = Time.time;
        rb.velocity = Vector2.up * jumpForce;
        an.Play("flapUp");
        
    }
}