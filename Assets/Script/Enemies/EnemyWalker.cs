using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class EnemyWalker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public int health;
    public float speed;

    public AudioMixerGroup audioMixer;

    AudioSource squishAudioSource;
    public AudioClip squishSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 1.0f;
        }

        if (health <= 0)
        {
            health = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If we are not dead - based on whether or not we are flipped - we walk in one direction
        if /*(!anim.GetBool("Death") && */(!anim.GetBool("Squish"))
        {
            if (sr.flipX)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            sr.flipX = !sr.flipX;
        }

        //if (collision.gameObject.tag == "PlayerProjectile")
        //{
        //    Projectile temp = collision.gameObject.GetComponent<Projectile>();
        //    TakeDamage(temp.damage);
        //    temp.DestroyProjectile();
        //}
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetBool("Death", true);
            rb.velocity = Vector2.zero;

            Destroy(gameObject);
        }
    }


    public void IsSquished()
    {
        anim.SetBool("Squish", true);
        rb.velocity = Vector2.zero;


        if (!squishAudioSource)
        {
            squishAudioSource = gameObject.AddComponent<AudioSource>();
            squishAudioSource.clip = squishSFX;
            squishAudioSource.outputAudioMixerGroup = audioMixer;
            squishAudioSource.loop = false;
        }

        squishAudioSource.Play();
    }

    public void FinishedDeath()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }


}