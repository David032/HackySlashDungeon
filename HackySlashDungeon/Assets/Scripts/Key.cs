using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    bool inTrigger;
    public AudioSource collectSound;

    public static bool bossDoorOpen = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<KeyCounter>().keysCollected += 1;
            Destroy(this.gameObject);
        }
    }
}
