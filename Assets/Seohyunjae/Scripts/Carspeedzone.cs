using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carspeedzone : MonoBehaviour
{
    public float carspeed = 1f;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Car"))
        {
            _other.gameObject.GetComponent<Car_Speed>().speed = carspeed;
        }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Car"))
        {
            _other.gameObject.GetComponent<Car_Speed>().speed = 5f;
        }
    }


}
