using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Player_Movement))]
public class PlayerFire : MonoBehaviour
{
    SpriteRenderer arthurSprite;
    Animator anim;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;

    //public AudioMixerGroup audioMixer;
    //AudioSource playerFireAudioSource;
    //public AudioClip playerFireSFX;

    // Start is called before the first frame update
    void Start()
    {
        arthurSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (projectileSpeed <= 0)
            projectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity Inspector Values Not Set");
    }

    // Update is called once per frame
    void Update()
    {   if (Time.timeScale == 1) { 
        if (Input.GetButtonDown("Fire1"))
        
            //if (!playerFireAudioSource)
            //{
            //    playerFireAudioSource = gameObject.AddComponent<AudioSource>();
            //    playerFireAudioSource.clip = playerFireSFX;
            //    playerFireAudioSource.outputAudioMixerGroup = audioMixer;
            //    playerFireAudioSource.loop = false;
            //}
            //playerFireAudioSource.Play();

            anim.SetBool("isAttacking", true);
        }

    }

    void FireProjectile()
    {
        if (arthurSprite.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = projectileSpeed = -2.0f;
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed = 2.0f; 
        }
    }

    void ResetFire()
    {
        anim.SetBool("isAttacking", false);
    }
}