using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDestroyer : MonoBehaviour {

    public GameObject bossPlinth;
    public GameObject Boss;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == bossPlinth)
        {
            Destroy(col.gameObject);
            Boss.GetComponent<EnemyController>().EnemyState = EnemyController.State.Attacking;
        }
    }
}
