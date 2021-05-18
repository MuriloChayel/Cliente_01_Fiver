using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;

    public float jumpForce;
    public float cooldown;

    private float timer;
    bool canFlap = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }
    private void Update()
    {
        bool press = Input.GetMouseButtonDown(0);
        FlapCooldownController();

        if (press && canFlap) { 
            Flap();
            timer = 0;
        }
    }
    void Flap()
    {
        an.Play("fly");
        rb.velocity = Vector2.up * jumpForce;
    }
    void FlapCooldownController()
    {
        timer += Time.deltaTime;

        if(timer < cooldown)
            canFlap = false;
        else
            canFlap = true;
    }
}