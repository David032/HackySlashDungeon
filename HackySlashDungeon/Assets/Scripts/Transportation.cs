using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class Transportation : MonoBehaviour {

    public GameObject[] Points;

    public int currentPoint = 0;

    private void Start()
    {        
        transform.position = Points[0].transform.position;
    }

    private void Update()
    {
        moveController();
    }

    void moveController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentPoint == 0)
            {
                move(1);
            }
            if (currentPoint == 1)
            {
                print("Not yet");
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentPoint == 2)
            {
                move(3);
            }
            if (currentPoint == 4)
            {
                move(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentPoint == 1)
            {
                move(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPoint == 2)
            {
                move(4);
            }
            if (currentPoint == 3)
            {
                move(2);
            }
        }
    }

    void move(int targetPoint)
    {
        currentPoint = targetPoint;
        transform.position = Points[targetPoint].transform.position;
    }
}
