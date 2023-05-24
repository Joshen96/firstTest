using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CarspeedConrol : MonoBehaviour
{
    // public GameObject speedcontrol;
    public GameObject car_speed;

    private void Start()
    {
        this.GetComponent<Scrollbar>().value = 0.25f;
    }


    public void Update()
    {
        car_speed.GetComponent<Car_Speed>().speed =
            this.GetComponent<Scrollbar>().value * 45;
    }



}
