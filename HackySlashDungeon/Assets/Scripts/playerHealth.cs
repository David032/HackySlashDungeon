using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

    public int Health = 100;
    public GameObject startPosition;

    void LateUpdate()
    {
        if (Health == 0)
        {
            transform.position = startPosition.transform.position;
            Health = 100;
        }
    }
}
