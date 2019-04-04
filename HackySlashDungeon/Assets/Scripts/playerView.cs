using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerView : MonoBehaviour {

    public GameObject playerEyes;

    float elapsedTime;
    Button thisButton;
    bool currentlyPeeking = false;

    void Start()
    {
        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
        playerEyes.SetActive(false);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (currentlyPeeking == false && elapsedTime > 5)
        {
            thisButton.GetComponentInChildren<Text>().text = "Peeking Available (p)";
            elapsedTime = 0;
        }
        if (currentlyPeeking == true && elapsedTime > 5)
        {
            playerEyes.SetActive(false);
            currentlyPeeking = false;
            elapsedTime = 0;
            thisButton.GetComponentInChildren<Text>().text = "Peeking Unavailable";
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            playerEyes.SetActive(true);
            currentlyPeeking = true;
            thisButton.GetComponentInChildren<Text>().text = "Peeking!";
        }
    }


    private void TaskOnClick()
    {
        playerEyes.SetActive(true);
        currentlyPeeking = true;
        thisButton.GetComponentInChildren<Text>().text = "Peeking!";
    }
}
