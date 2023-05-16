using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carwheelchange : MonoBehaviour
{
    public GameObject wheel;
    public float xspeed = 180;

    // Update is called once per frame
    void Update()
    {
        wheel.transform.Rotate(xspeed*Time.deltaTime, 0, 0);
    }
}
