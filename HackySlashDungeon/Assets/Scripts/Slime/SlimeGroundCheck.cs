using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGroundCheck : MonoBehaviour {

    public GameObject slimey;
    private EnemyPatrol enemy_script;

	// Use this for initialization
	void Start ()
    {
        slimey = transform.parent.gameObject;
        enemy_script = slimey.GetComponent<EnemyPatrol>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Vector3 velocity_calc = slimey.GetComponent<Rigidbody>().velocity;
        velocity_calc.y = 0;
        velocity_calc.z = 0;
        velocity_calc.x = 0;
        slimey.GetComponent<Rigidbody>().velocity = velocity_calc;
        enemy_script.is_grounded = true;
        //slimey_script.canMove = false;
    }

    private void OnTriggerExit(Collider other)
    {
        enemy_script.is_grounded = false;
    }
}
