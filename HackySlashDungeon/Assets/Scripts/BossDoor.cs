using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public bool bossDoorOpen = false;

	void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<KeyCounter>().keysCollected == 3)
        {
            this.gameObject.SetActive(false);
        }
    }
}
