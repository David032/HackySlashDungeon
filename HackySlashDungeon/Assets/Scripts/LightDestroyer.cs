using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This dead? Think this is useless
public class LightDestroyer : MonoBehaviour {

    public GameObject bossPlinth;
    public GameObject Boss;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == bossPlinth)
        {
            print("falling!");
            Destroy(col.gameObject);
            Boss.GetComponent<EnemyController>().EnemyState = EnemyController.State.Attacking;
        }
    }
}
