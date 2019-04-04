using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : MonoBehaviour {

    public GameObject player;
    Animation trap;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trap = GetComponentInParent<Animation>();
    }

    void OnCollisionEnter(GameObject other)
    {        
        print("colliding");
        if (other == player)
        {
            print("spearing!");
            player.GetComponent<playerHealth>().Health -= 10;
            trap.Rewind();
        }
        if (other.gameObject.tag == "Shield")
        {
            print("Doged!");
            trap.Rewind();
        }
    }
}
