using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer arthurSprite;
    AudioSource pickupAudioSource;
    AudioSource jumpAudioSource;

    public int bounceForce;
    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public AudioClip jumpSFX;
    public AudioMixerGroup audioMixer;

    AudioSource squishAudioSource;
    public AudioClip squishSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        arthurSprite = GetComponent<SpriteRenderer>();
        //pickupAudioSource = GetComponent<AudioSource>();

        if (speed <= 0)
        {
            speed = 2.5f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (bounceForce <=0)
        {
            bounceForce = 100;
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
        if (Time.timeScale == 1)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);

                if (!jumpAudioSource)
                {
                    jumpAudioSource = gameObject.AddComponent<AudioSource>();
                    jumpAudioSource.clip = jumpSFX;
                    jumpAudioSource.outputAudioMixerGroup = audioMixer;
                    jumpAudioSource.loop = false;
                }

                jumpAudioSource.Play();



            }

            Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
            rb.velocity = moveDirection;

            anim.SetFloat("speed", Mathf.Abs(horizontalInput));
            anim.SetBool("isGrounded", isGrounded);

            if (arthurSprite.flipX && horizontalInput > 0 || !arthurSprite.flipX && horizontalInput < 0)
                arthurSprite.flipX = !arthurSprite.flipX;
        }
    }
    public void CollectibleSound(AudioClip pickupAudio)
    {
        if (!pickupAudioSource)
        {
            pickupAudioSource = gameObject.AddComponent<AudioSource>();
            pickupAudioSource.outputAudioMixerGroup = audioMixer;
        }

        pickupAudioSource.clip = pickupAudio;
        pickupAudioSource.Play();
    }

    public void IsDead()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Squish")
        {
            if (!isGrounded)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);


            }
        }
    }
}