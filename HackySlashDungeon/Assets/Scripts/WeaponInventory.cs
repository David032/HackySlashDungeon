using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    public GameObject[] weapons = new GameObject[6];
    public GameObject[] shield = new GameObject[6];

    public int weapon_number = 0;
    public int shield_number = 0;

    public int amount_of_weapons = 0;
    public int amount_of_shields = 0;
    //2nd child of left arm/right arm etc aka +1 to shield/weapon number simple stuff

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One)) //A (Down Right)
        {
            if (weapon_number > 0)
            {
                weapon_number--;
            }
            else
            {
                weapon_number = amount_of_weapons;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two)) //B (Up Right)
        {
            if(weapon_number < amount_of_weapons)
            {
                weapon_number++;
            }
            else
            {
                weapon_number = 0;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Three)) //X (Down Left)
        {
            if (shield_number > 0)
            {
                shield_number--;
            }
            else
            {
                shield_number = amount_of_shields;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Four)) //Y (Up Left)
        {
            if (shield_number < amount_of_shields)
            {
                shield_number++;
            }
            else
            {
                shield_number = 0;
            }
        }

        for (int i = 0; i < amount_of_weapons; i++)
        {
            weapons[i].SetActive(false);
        }

        for (int i = 0; i < amount_of_shields; i++)
        {
            shield[i].SetActive(false);
        }

        if(amount_of_shields > 0)
        {
            if (shield[shield_number] != null)
            {
                shield[shield_number].SetActive(true);
            }
        }

        if (amount_of_weapons > 0)
        {
            if (weapons[weapon_number] != null)
            {
                weapons[weapon_number].SetActive(true);
            }
        }
    }
}
