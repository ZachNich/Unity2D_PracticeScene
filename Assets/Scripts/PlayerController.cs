using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float playerSpeed = 3f;
    [SerializeField] float playerJump = 4f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Better than update for handling physics
    private void FixedUpdate()
    {
        // Checks if player is grounded or not
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            animator.Play("player_jump");
        }

        // Horizontal movement and animation
        if (Input.GetKey("d"))
        {
            spriteRenderer.flipX = false;
            animator.Play("player_run");
            rb2d.velocity = new Vector2(playerSpeed, rb2d.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            spriteRenderer.flipX = true;
            animator.Play("player_run");
            rb2d.velocity = new Vector2(-playerSpeed, rb2d.velocity.y);
        }
        else
        {
            animator.Play("player_idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        // Vertical movement and animation
        if ((Input.GetKey("space") || Input.GetKey("w")) && isGrounded == true)
        {
            animator.Play("player_jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, playerJump);
        }
    }
}
