using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
    //Right now, this isn't so much a spawner as it is an activator

    public GameObject enemy;

    Button thisButton;

    void Start()
    {
        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            enemy.gameObject.SetActive(true);
        }
    }

    private void TaskOnClick()
    {
        enemy.gameObject.SetActive(true);
    }

}
