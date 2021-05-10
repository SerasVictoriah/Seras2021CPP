using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player_Movement))]
public class PlayerFire : MonoBehaviour
{
    SpriteRenderer arthurSprite;
    Animator anim;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;

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
    {
        if (Input.GetButtonDown("Fire1"))
        {
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