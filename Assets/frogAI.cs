using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogAI : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    [SerializeField] float frogSpeed = 3f;
    [SerializeField] float frogJump = 5f;
    [SerializeField] Transform groundCheck;
    float jumpDir = -1;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {        
        // Checks if frog is grounded or not
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        print(isGrounded);

        if (jumpDir > 0 && isGrounded)
        {
            // jump right
            //spriteRenderer.flipX = true;
            rb2d.velocity = new Vector2(frogSpeed, frogJump);
            jumpDir -= frogSpeed;
        }
        else if (jumpDir < 0 && isGrounded)
        {
            // jump left
            //spriteRenderer.flipX = false;
            rb2d.velocity = new Vector2(-frogSpeed, frogJump);
            jumpDir += frogSpeed;
        }
    }
}
