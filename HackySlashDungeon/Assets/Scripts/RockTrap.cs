using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap : MonoBehaviour {

    bool spawningRocks;
    public GameObject rock;

    void Awake()
    {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(rock);
            }
        
    }
}
