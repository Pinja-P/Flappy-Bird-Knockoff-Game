using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TheBird : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            animator.SetTrigger("SpaceBar");
        }
    }

    // When bird hits a pipe
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Changes to dead animation picture
        animator.SetTrigger("GotHit");
        logic.gameOver();
        birdIsAlive = false;
     
    }


}
