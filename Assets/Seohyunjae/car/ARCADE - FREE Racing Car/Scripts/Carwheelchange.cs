using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Carwheelchange : MonoBehaviour
{
    public Carmovement Carmovement;
    public GameObject[] wheels;
    public float xspeed = 180;

    // Update is called once per frame
    void Update()
    {
        if (Carmovement.isStopcar == false)
        {
            foreach(GameObject wheel in wheels) {
                wheel.transform.Rotate(xspeed * Time.deltaTime, 0, 0);
            }
            
        }
        else
        {

        }
    }
}
