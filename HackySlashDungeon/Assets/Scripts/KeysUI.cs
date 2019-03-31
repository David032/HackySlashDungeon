using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysUI : MonoBehaviour {
    public Text keysText;

	
	// Update is called once per frame
	void Update ()
    {
        keysText.text = "Current Keys:" + GameObject.FindGameObjectWithTag("Player").GetComponent<KeyCounter>().keysCollected.ToString();
	}
}
