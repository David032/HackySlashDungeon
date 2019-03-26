using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public Slider HealthBar;
    public EnemyPatrol enemy_info;
    public int hp;
    private GameObject canvas_obj;
    private GameObject camera_obj;

    // Use this for initialization
    void Start()
    {
        HealthBar = GetComponent<Slider>();
        canvas_obj = this.transform.parent.gameObject;
        enemy_info = canvas_obj.transform.parent.gameObject.GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        camera_obj = Camera.current.gameObject;
        canvas_obj.transform.LookAt(camera_obj.transform);
        canvas_obj.transform.eulerAngles = new Vector3(0, canvas_obj.transform.eulerAngles.y, 0);
        HealthBar.maxValue = enemy_info.max_hp;
        hp = enemy_info.hp;
        HealthBar.value = enemy_info.hp;
    }
}