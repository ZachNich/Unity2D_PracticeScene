using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    private bool isGrounded;
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
    public void HandleMovement()
    {
        // Checks if player is grounded or not
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            if (rb2d.velocity.y > 0)
            {
                animator.Play("player_jump_up");
            }
            else if (rb2d.velocity.y < 0)
            {
                animator.Play("player_jump_down");
            }
        }

        // Horizontal movement and animation
        if (Input.GetKey("d"))
        {
            if (isGrounded)
            {
                animator.Play("player_run");
            }
            spriteRenderer.flipX = false;
            rb2d.velocity = new Vector2(playerSpeed, rb2d.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            if (isGrounded)
            {
                animator.Play("player_run");
            }
            spriteRenderer.flipX = true;
            rb2d.velocity = new Vector2(-playerSpeed, rb2d.velocity.y);
        }
        else
        {
            if (isGrounded)
            {
                animator.Play("player_idle");
            }
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        // Vertical movement and animation
        if ((Input.GetKey("space") || Input.GetKey("w")) && isGrounded == true)
        {
            animator.Play("player_jump_up");
            rb2d.velocity = new Vector2(rb2d.velocity.x, playerJump);
        }
    }
}
