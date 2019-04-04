using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public bool bossDoorOpen = false;
    public GameObject[] bossPoints;
    public GameObject particleSystem;

    void Start()
    {
        for (int i = 0; i < bossPoints.Length; i++)
        {
            bossPoints[i].SetActive(false);
        }
    }

    void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<KeyCounter>().keysCollected == 3)
        {
            this.gameObject.SetActive(false);
            for (int i = 0; i < bossPoints.Length; i++)
            {
                bossPoints[i].SetActive(true);
            }
            particleSystem.SetActive(true);
        }
    }
}
