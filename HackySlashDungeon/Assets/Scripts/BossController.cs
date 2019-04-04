using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public int health = 10;
    public GameObject[] finalpoints;
    public GameObject treasureDoor;

    void Start()
    {
        for (int i = 0; i < finalpoints.Length; i++)
        {
            finalpoints[i].SetActive(false);
        }
        health = GetComponent<EnemyController>().health;
    }

    void Update()
    {
        health = GetComponent<EnemyController>().health;
    }

    void FixedUpdate()
    {


        if (health <= 0)
        {
            for (int i = 0; i < finalpoints.Length; i++)
            {
                finalpoints[i].SetActive(true);
            }
            treasureDoor.SetActive(false);
        }
    }

}
