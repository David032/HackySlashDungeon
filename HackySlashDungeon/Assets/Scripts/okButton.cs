using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class okButton : MonoBehaviour {

    Button thisButton;
    public GameObject StartTExt;

    // Use this for initialization
    void Start () {
        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
    }
	

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartTExt.SetActive(false);
        }
    }

    private void TaskOnClick()
    {
        StartTExt.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
