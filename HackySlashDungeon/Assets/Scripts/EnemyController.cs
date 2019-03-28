using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int health = 2;
    public AudioSource deathSound;
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

    float speed = 3.0f;
    GameObject Player;
    GameObject Entity;
    float PlayerDistance;
    float elapsedTime;
    float stamina;
    float playerDistance;
    bool to;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Entity = gameObject;
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
                patrol();
                break;
            case State.Attacking:
                GetComponent<MeshRenderer>().material = angryMat;
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            if (health == 0)
            {
                deathSound.Play();
                this.gameObject.SetActive(false);
            }
            else
            {
                health -= 1;
            }

        }
    }

    void patrol()
    {
        elapsedTime += Time.deltaTime;

        float step = speed * Time.deltaTime;

        if (elapsedTime > 5f)
        {
            if (to == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationPos.transform.position, step);
            }
            if (to == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, step);
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




}
