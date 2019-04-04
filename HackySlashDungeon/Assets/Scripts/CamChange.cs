using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamChange : MonoBehaviour {

    public Camera targetCam;
    public KeyCode CamNumber;

    Button thisButton;

    void Start()
    {
        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
        if (Input.GetKey(CamNumber))
        {
            this.GetComponentInParent<Camera>().gameObject.SetActive(false);
            targetCam.gameObject.SetActive(true);
        }
    }

    private void TaskOnClick()
    {
        this.GetComponentInParent<Camera>().gameObject.SetActive(false);
        targetCam.gameObject.SetActive(true);
    }
}
