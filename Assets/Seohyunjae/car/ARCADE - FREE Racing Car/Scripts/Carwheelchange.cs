using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Carwheelchange : MonoBehaviour
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
        
        if(carmovement.isStopcar)
        {
            //Debug.Log("����");
        }
        else
        {
           // Debug.Log("������");
            foreach (GameObject wheel in wheels) 
            {
                wheel.transform.Rotate(0, xspeed * Time.deltaTime, 0);
            }
            
        }
    
    }
}
