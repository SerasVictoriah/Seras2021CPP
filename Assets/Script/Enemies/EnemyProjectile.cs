using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyProjectile : MonoBehaviour {

    public float speed;
    public float lifetime;

    private Transform player;
    private Vector2 target;

    public AudioMixerGroup audioMixer;
    AudioSource enemyFireAudioSource;
    public AudioClip enemyFireSFX;

    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }

        Destroy(gameObject, lifetime);
    }



    void Update(){

        Vector3 dir = player.transform.position - transform.position;
        target = new Vector2(player.position.x, player.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (!enemyFireAudioSource)
        {
            enemyFireAudioSource = gameObject.AddComponent<AudioSource>();
            enemyFireAudioSource.clip = enemyFireSFX;
            enemyFireAudioSource.outputAudioMixerGroup = audioMixer;
            enemyFireAudioSource.loop = false;
        }
        enemyFireAudioSource.Play();

    }

        void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            DestroyEnemyProjectile();
            GameManager.instance.lives--;
        }
    
    }


        void DestroyEnemyProjectile()
    {

        Destroy(gameObject);
    }

    
}
