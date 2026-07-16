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
    public float DeadZoneBelow = -25;
    public float DeadZoneAbove = 25;

    public Animator animator;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            animator.SetTrigger("SpaceBar");
            AudioManager.Instance.PlaySFX("Flap");
        }

        if (birdIsAlive == true && transform.position.y < DeadZoneBelow || transform.position.y > DeadZoneAbove)
        {
            animator.SetTrigger("GotHit");
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    // When bird hits a pipe
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive == true)
        {
            // Changes to dead animation picture
            animator.SetTrigger("GotHit");
            logic.gameOver();
            birdIsAlive = false;
        }
     
    }


}
