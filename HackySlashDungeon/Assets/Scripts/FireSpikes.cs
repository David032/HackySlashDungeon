using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpikes : MonoBehaviour {
    GameObject spike;

    private void TaskOnClick()
    {
        spike.GetComponent<Animation>().Play();
    }
}
