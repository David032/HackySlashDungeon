using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public int hp = 100;
    [HideInInspector] public int max_hp = 100;
    public GameObject SlimeCube;

    //public GameObject target;
    public List<GameObject> targets;
    public GameObject Player;
    public GameObject Player_target;
    public bool random_target = false;
    public int target_number = 0;

    public bool is_grounded = false;

    private bool movementCalculated = false;
    public bool isPlayerTarget = false;

    private bool is_inside = false;

    private Vector3 movement_vector;
    private Vector3 player_jumped_position;

    private float movement_wait_delta = 0;
    public float time_between_movement = 1;
    public bool canMove = false;

    public Vector3 debug_1;
    public Vector3 debug_2;

    // Use this for initialization
    void Start()
    {
        SlimeCube = this.gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (hp <= 0)
            {
                Vector3 this_enemy_position = transform.position;

                Destroy(this.gameObject);
            }
            else
            {
                int max_targets = targets.Count;

                Vector3 target_position = targets[target_number].transform.position;

                if (isPlayerTarget)
                {
                    target_position = Player_target.transform.position;
                }
                else
                {
                    target_position = targets[target_number].transform.position;
                }

                if (!movementCalculated)
                {
                    movement_vector = target_position - transform.position;
                    movementCalculated = true;
                }

                Vector3 calculated_position = target_position - transform.position;

                float length_of_position = 0;

                float positive_x_pos = 0;
                float positive_z_pos = 0;

                if (calculated_position.x < 0)
                {
                    positive_x_pos = -calculated_position.x;
                }
                else
                {
                    positive_x_pos = calculated_position.x;
                }

                if (calculated_position.z < 0)
                {
                    positive_z_pos = -calculated_position.z;
                }
                else
                {
                    positive_z_pos = calculated_position.z;
                }

                length_of_position = positive_z_pos + positive_x_pos;

                debug_1 = target_position;
                debug_2 = transform.position;

                if ((transform.position.x + 0.5f < target_position.x || transform.position.x - 0.5f > target_position.x) ||
                   (transform.position.z + 0.5f < target_position.z || transform.position.z - 0.5f > target_position.z))
                {
                    transform.Translate(calculated_position * Time.deltaTime);
                }
                else
                {
                    if (random_target && max_targets > 3)
                    {
                        int old_target = target_number;
                        while (target_number == old_target)
                        {
                            System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
                            target_number = rnd.Next(0, max_targets - 1);
                        }
                    }
                    else
                    {
                        if (target_number < max_targets - 1)
                        {
                            target_number += 1;
                        }
                        else
                        {
                            target_number = 0;
                        }
                    }
                    is_inside = false;
                    canMove = false;
                }

            }
        }
        else
        {
            movement_wait_delta += Time.deltaTime;
            if (movement_wait_delta >= time_between_movement)
            {
                canMove = true;
                movement_wait_delta = 0;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerTarget = true;
            canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerTarget = false;
            canMove = false;
        }
    }
}
