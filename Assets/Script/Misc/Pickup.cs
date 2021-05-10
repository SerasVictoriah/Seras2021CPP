using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES
    }

    public CollectibleType currentCollectible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTIBLE:
                       Player_Movement pmScript = collision.gameObject.GetComponent<Player_Movement>();
                        pmScript.score++;
                    break;

                case CollectibleType.LIVES:
                        pmScript = collision.gameObject.GetComponent<Player_Movement>();
                        pmScript.lives++;
                    break;

                case CollectibleType.POWERUP:
                    collision.gameObject.GetComponent<Player_Movement>();
                    break;

            }
                Destroy(gameObject);
        }
    }

}

