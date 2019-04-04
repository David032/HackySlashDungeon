using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
        }
    }
}
