using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            GameManager.instance.lives--;
            Destroy(collision.gameObject);

        }



        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "WalkingEnemy")
        {
            GameManager.instance.lives--;
        }
    }
}