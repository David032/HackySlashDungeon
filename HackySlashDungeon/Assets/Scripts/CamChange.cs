using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamChange : MonoBehaviour {

    public Camera targetCam;

    Button thisButton;

    void Start()
    {
        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        this.GetComponentInParent<Camera>().gameObject.SetActive(false);
        targetCam.gameObject.SetActive(true);
    }
}
