using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class racingcarwheels : MonoBehaviour
{
    public Carmovement carmovement;
    public GameObject[] wheels;
    public float xspeed = 180;


    private void Awake()
    {
        carmovement.isStopcar = false;

    }
    // Update is called once per frame
    void Update()
    {

        if (carmovement.isStopcar)
        {
            //Debug.Log("∏ÿ√„");
        }
        else
        {
            // Debug.Log("øÚ¡˜¿”");
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(xspeed * Time.deltaTime,0, 0);
            }

        }
        if (true)
        {

        }

    }
}

