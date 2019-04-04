using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlocker : MonoBehaviour {

    public GameObject[] points;
    public string weapon;

    private void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == weapon)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == weapon)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}
