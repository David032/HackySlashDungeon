using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text playerHealth;

    void Update()
    {
        playerHealth.text = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>().Health.ToString() + "hp";
    }

}
