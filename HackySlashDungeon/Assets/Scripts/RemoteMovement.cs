using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using Oculus;
using OVR;

public class RemoteMovement : MonoBehaviour {

    private void FixedUpdate()
    {
        OVRInput.Update();
        KeyHandler();
    }

    void KeyHandler()
    {
        if (OVRInput.Get(OVRInput.Button.DpadLeft))
        {
            print("left button pressed");
        }
        if (OVRInput.Get(OVRInput.Button.DpadRight))
        {
            print("right button pressed");
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            print("round button pressed");
        }
        if (OVRInput.GetUp(OVRInput.Button.DpadUp, OVRInput.Controller.Remote))
        {
            Debug.Log("remote click");
        }
    }
}
