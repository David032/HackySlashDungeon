using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlinth : MonoBehaviour {
    public GameObject particle;
    public GameObject boss;

    void OnParticleCollision(GameObject other)
    {
        this.gameObject.SetActive(false);
        particle.SetActive(false);
        print("destroyed via particle");
        boss.GetComponent<EnemyController>().EnemyState = EnemyController.State.Attacking;
    }
}
