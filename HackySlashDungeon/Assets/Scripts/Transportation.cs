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
    public enum Motion
    {
        RemotePointToPoint,
        Linear
    }

    public GameObject[] Points;
    public Motion MovementType = Motion.RemotePointToPoint;

    public int currentPoint = 0;
    public bool canMove = true;
    public float time = 0;

    private void Start()
    {        
        transform.position = Points[0].transform.position;

        if (MovementType == Motion.Linear)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Destroy(Points[i]);
            }
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            canMove = true;
        }

        if (MovementType == Motion.RemotePointToPoint)
        {
            OVRInput.Update();
            moveController();
        }
        else if (MovementType == Motion.Linear)
        {
            GetComponent<OVRPlayerController>().EnableLinearMovement = true;
            remoteMovement();
        }

        crouch();
    }

    void crouch()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localScale.Set(1, 0.5f, 1);
        }
    }

    void remoteMovement()
    {
        OVRInput.Update();
        if (OVRInput.Get(OVRInput.RawButton.DpadLeft) && canMove)
        {
            transform.Translate(Vector3.left / 4);
        }
        if (OVRInput.Get(OVRInput.RawButton.DpadRight) && canMove)
        {
            transform.Translate(Vector3.right / 4);
        }
    }

    void moveController()
    {
        OVRInput.Update();

        if (OVRInput.Get(OVRInput.RawButton.DpadUp) && canMove)
        {
            print("Attempting to move forward!");
            if (currentPoint == 0)
            {
                move(1);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 1 && canMove)
            {
                move(2);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 6 && canMove)
            {
                move(5);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 7 && canMove)
            {
                move(6);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 8 && canMove)
            {
                move(3);
                canMove = false;
                time = 0;
            }
        }

        if (OVRInput.Get(OVRInput.Button.DpadLeft) && canMove)
        {
            if (currentPoint == 2 && canMove)
            {
                move(3);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 4 && canMove)
            {
                move(2);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 5 && canMove)
            {
                move(4);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 8 && canMove)
            {
                move(9);
                canMove = false;
                time = 0;
            }
        }

        if (OVRInput.Get(OVRInput.Button.DpadDown) && canMove)
        {
            if (currentPoint == 1 && canMove)
            {
                move(0);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 2 && canMove)
            {
                move(1);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 5 && canMove)
            {
                move(6);
                canMove = false;
                time = 0;
            }
            else if (currentPoint == 6 && canMove)
            {
                move(7);
                canMove = false;
                time = 0;
            }
        }

        if (OVRInput.Get(OVRInput.Button.DpadRight) && canMove)
        {
            if (currentPoint == 2 && canMove)
            {
                move(4);
                canMove = false;
            }
            else if (currentPoint == 3 && canMove)
            {
                move(2);
                canMove = false;
            }
            else if (currentPoint == 4 && canMove)
            {
                move(5);
                canMove = false;
            }
        }
    }

    void move(int targetPoint)
    {
        currentPoint = targetPoint;
        transform.position = Points[targetPoint].transform.position;
    }
}
