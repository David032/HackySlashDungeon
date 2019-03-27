using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMenu : MonoBehaviour {

    public GameObject camMenu;

    Button thisButton;

    void Start()
    {
        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        camMenu.SetActive(!camMenu.activeInHierarchy);
    }
}
