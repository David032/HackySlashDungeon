using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRPickup : MonoBehaviour {

    public bool has_picked_up = false;
    public string which_hand = "";

    public Vector3 position_in_hand;
    public Vector3 angle_in_hand;

    private bool pickedUp = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject right_hand = GameObject.Find("hand_right_renderPart_0");
        GameObject left_hand = GameObject.Find("hand_left_renderPart_0");
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        WeaponInventory inventory = Player.GetComponent<WeaponInventory>();

        //else if (which_hand == "AvatarGrabberRight")
        if (has_picked_up)
        {
            Destroy(this.GetComponent<Rigidbody>());
            if(this.gameObject.tag == "Shield")
            {
                if(inventory.amount_of_shields < 5 && !pickedUp)
                {
                    this.gameObject.transform.parent = left_hand.transform;

                    transform.localPosition = position_in_hand;
                    transform.localEulerAngles = angle_in_hand;

                    inventory.shield[inventory.amount_of_shields] = this.gameObject;
                    inventory.amount_of_shields += 1;
                    pickedUp = true;
                }
            }
            else if (this.gameObject.tag == "Weapon")
            {
                if (inventory.amount_of_weapons < 5 && !pickedUp)
                {
                    this.gameObject.transform.parent = right_hand.transform;

                    transform.localPosition = position_in_hand;
                    transform.localEulerAngles = angle_in_hand;

                    inventory.weapons[inventory.amount_of_weapons] = this.gameObject;
                    inventory.amount_of_weapons += 1;
                    pickedUp = true;
                }
            }
        }
    }
}
