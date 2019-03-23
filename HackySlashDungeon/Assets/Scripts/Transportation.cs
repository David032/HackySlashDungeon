using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

//0:Starting corridor
//1:NorthCorridor
//2:4WayHub
//3:WesternCorridor
//4:EasternCorridor
//5:EasternCorridorFar
//6:LibraryLower
//7:LibraryUpper

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

        print(Input.GetAxis("RemoteX"));
        print(Input.GetAxis("RemoteY"));
    }

    void moveController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentPoint == 0)
            {
                move(1);
            }
            else if (currentPoint == 1)
            {
                move(2);
            }
            else if (currentPoint == 6)
            {
                move(5);
            }
            else if (currentPoint == 7)
            {
                move(6);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentPoint == 2)
            {
                move(3);
            }
            else if (currentPoint == 4)
            {
                move(2);
            }
            else if (currentPoint == 5)
            {
                move(4);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentPoint == 1)
            {
                move(0);
            }
            else if (currentPoint == 2)
            {
                move(1);
            }
            else if (currentPoint == 5)
            {
                move(6);
            }
            else if (currentPoint == 6)
            {
                move(7);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPoint == 2)
            {
                move(4);
            }
            else if (currentPoint == 3)
            {
                move(2);
            }
            else if (currentPoint == 4)
            {
                move(5);
            }
        }
    }

    void move(int targetPoint)
    {
        currentPoint = targetPoint;
        transform.position = Points[targetPoint].transform.position;
    }
}
