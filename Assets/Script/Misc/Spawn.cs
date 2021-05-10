using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        int Randoms = Random.Range(1, 4);
        if (Randoms == 1)
        {
            Instantiate(spawnedObject[0], transform.position, transform.rotation);
        }
        else if (Randoms == 2)
        {
            Instantiate(spawnedObject[1], transform.position, transform.rotation);
        }
        else
        {
            Instantiate(spawnedObject[2], transform.position, transform.rotation);
        }
    }
    //gameObject.findobjectswithtag.

    // Update is called once per frame
    void Update()
    {

    }
}