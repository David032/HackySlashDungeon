using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamage : MonoBehaviour {

    public float elapsedTime;

    void OnCollisionEnter(Collision collision)
    {
        elapsedTime += Time.deltaTime;

        if (collision.gameObject.tag == "Player" && elapsedTime < 0.75)
        {
            collision.gameObject.GetComponent<playerHealth>().Health -= 1;
            elapsedTime = 0;
        }
    }
}
