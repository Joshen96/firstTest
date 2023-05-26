using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BusCarwheelchange : MonoBehaviour
{
    public Carmovement carmovement;
    public GameObject[] wheels;
    public GameObject CarspeedControl;
    public float xspeed = 180;
  

    private void Awake()
    {
        carmovement.isStopcar = false;

    }
    // Update is called once per frame
    void Update()
    {
        
        if(carmovement.speed == 0)
        {
            
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(0, 0, 0);
            }

        }
        if(carmovement.isStopcar)
        {
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(0, 0, 0);
            }
        }
        else
        {
           // Debug.Log("¿òÁ÷ÀÓ");
            foreach (GameObject wheel in wheels) 
            {
                wheel.transform.Rotate(0, -xspeed * Time.deltaTime, 0);
            }
            
        }
        if (CarspeedControl.GetComponent<Scrollbar>().value == 0)
        {
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(0, 0, 0);
            }
        }


    }
}
