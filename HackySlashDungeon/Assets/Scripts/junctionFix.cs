using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junctionFix : MonoBehaviour {

    public GameObject ShieldLeft;
    public GameObject SwordRight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            ShieldLeft.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            SwordRight.SetActive(false);
        }
    }
}
