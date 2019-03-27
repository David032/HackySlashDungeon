using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCombat : MonoBehaviour {

    public AudioSource deathSound;
    public int health = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            if (health == 0)
            {
                deathSound.Play();
                this.gameObject.SetActive(false);
            }
            else
            {
                health -= 1;
            }

        }
    }
}
