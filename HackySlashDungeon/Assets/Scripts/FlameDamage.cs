using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamage : MonoBehaviour {

    public float elapsedTime;
    public GameObject player;

    //void OnCollisionEnter(Collision collision)
    //{
    //    elapsedTime += Time.deltaTime;

    //    if (collision.gameObject == player)
    //    {
    //        print("buring!");
    //        player.GetComponent<playerHealth>().Health -= 1;
    //        elapsedTime = 0;
    //    }
    //}
    void OnParticleCollision(GameObject other)
    {
        elapsedTime += Time.deltaTime;
        print("colliding");
        if (other == player)
        {
            print("buring!");
            player.GetComponent<playerHealth>().Health -= 1;
            elapsedTime = 0;
        }
    }
}
