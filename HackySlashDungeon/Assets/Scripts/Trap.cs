using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour {

    public GameObject trap;
    public KeyCode key;

    Button thisButton;
    ParticleSystem trapEffect;

    void Start()
    {
        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
        trapEffect = trap.GetComponentInChildren<ParticleSystem>();
    }

    private void TaskOnClick()
    {
        trapEffect.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            trapEffect.Play();
        }
    }
}
