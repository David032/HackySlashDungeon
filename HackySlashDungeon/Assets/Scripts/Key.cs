using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool inTrigger;
    public float speed = 10f;
    public AudioSource collectSound;

    public static bool bossDoorOpen = false;


    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            KeyCounter.keysCollected++;
            Destroy(this.gameObject);
            // render score
        }

        if (KeyCounter.keysCollected >= 3)
        {
            bossDoorOpen = true;
        }
        else
        {
            bossDoorOpen = false;
        }
    }
}
