using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlinth : MonoBehaviour {
    public GameObject particle;

    void OnParticleCollision(GameObject other)
    {
        this.gameObject.SetActive(false);
        particle.SetActive(false);
        print("destroyed via particle");
    }
}
