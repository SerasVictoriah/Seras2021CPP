using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer arthurSprite;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public int score = 0;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        arthurSprite = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 2.5f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please assign a ground check object");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);

        if (arthurSprite.flipX && horizontalInput > 0 || !arthurSprite.flipX && horizontalInput < 0)
            arthurSprite.flipX = !arthurSprite.flipX;

    }

    
}