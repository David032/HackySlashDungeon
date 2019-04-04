﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int health = 2;
    public AudioSource deathSound;
    public AudioSource attackSound;
    public enum State
    {
        Idle,
        Patrolling,
        Attacking
    }
    public GameObject startPos;
    public GameObject destinationPos;
    public State EnemyState = State.Idle;
    public Material angryMat;
    public ParticleSystem death;

    float speed = 3.0f;
    GameObject Player;
    GameObject Entity;
    public float PlayerDistance;
    float elapsedTime;
    float stamina;
    float playerDistance;
    bool to;
    Material normalMat;
    bool hitPlayer = true;
    Transform PlayerTransform;
    Transform EntityTransform;
    bool isBeingStabbed;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Entity = gameObject;
        normalMat = this.gameObject.GetComponent<MeshRenderer>().material;
        PlayerTransform = Player.transform;
        EntityTransform = Entity.transform;
    }

    void Update()
    {
        playerDistance = Vector3.Distance(Entity.GetComponent<Transform>().position, Player.GetComponent<Transform>().position);

        if (playerDistance < 5)
        {
            EnemyState = State.Attacking;
        }
        if (playerDistance > 5)
        {
            EnemyState = State.Patrolling;
        }
    }

    void FixedUpdate()
    {
        stamina += Time.deltaTime;
        float step = speed * Time.deltaTime;

        switch (EnemyState)
        {
            case State.Idle:
                break;
            case State.Patrolling:
                GetComponent<MeshRenderer>().material = normalMat;
                patrol();
                break;
            case State.Attacking:
                GetComponent<MeshRenderer>().material = angryMat;
                Attack();
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon" && !isBeingStabbed)
        {
            if (health == 0)
            {
                deathSound.Play();
                death.Play();
                this.gameObject.SetActive(false);
            }
            else
            {
                health -= 1;
                isBeingStabbed = true;
            }

        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerHealth>().Health -= 1;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerHealth>().Health -= 1;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            isBeingStabbed = false;
        }
    }

    void patrol()
    {
        elapsedTime += Time.deltaTime;
        float patrolStep = speed * Time.deltaTime;

        if (elapsedTime > 5f)
        {
            if (to == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationPos.transform.position, patrolStep);
            }
            if (to == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, patrolStep);
            }
        }

        if (to == true)
        {
            if (transform.position == destinationPos.transform.position)
            {
                to = false;
                elapsedTime = 0;
            }
        }
        if (to == false)
        {
            if (transform.position == startPos.transform.position)
            {
                to = true;
                elapsedTime = 0;
            }
        }
    }

    void Attack()
    {
        elapsedTime += Time.deltaTime;
        float combatStep = speed * Time.deltaTime;

        EntityTransform.LookAt(PlayerTransform);
        EntityTransform.Rotate(EntityTransform.rotation.x, (EntityTransform.rotation.y - 90), 0);
        if (stamina > 0.5 && !hitPlayer)
        {
            EntityTransform.position = Vector3.MoveTowards(EntityTransform.position, PlayerTransform.position, (combatStep * 5));
            //attackSound.Play();
            stamina = 0;
        }
        else if (stamina > 0.5 && hitPlayer)
        {
            EntityTransform.position = Vector3.MoveTowards(EntityTransform.position, PlayerTransform.position, (combatStep * -10));
            stamina = 0;
            hitPlayer = false;
        }
    }


}
