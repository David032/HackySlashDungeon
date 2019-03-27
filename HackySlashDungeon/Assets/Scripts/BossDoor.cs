using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public bool bossDoorOpen = false;

	void Update ()
    {
        if (Key.bossDoorOpen == true)
        {
            bossDoorOpen = true;
        }
        if (bossDoorOpen == true)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -130.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        if (bossDoorOpen == false)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
    }
}
