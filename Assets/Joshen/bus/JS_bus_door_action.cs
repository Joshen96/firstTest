using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class JS_bus_door_action : MonoBehaviour
{
    public Animator door;

    void Start()
    {
       

       // StartCoroutine(opendelay());
    }

    public void open()
    {
        StartCoroutine(bus_opendoor());
    }

    public void close()
    {
        StartCoroutine(bus_closedoor());
    }




 
    IEnumerator bus_opendoor()
    {
        door.Play("busdoor_Open");
        yield return new WaitForSeconds(5);
        door.Play("busdoor_Close");

    }
    IEnumerator bus_opendoor2()
    {
        door.Play("busdoor_Open");
        yield return new WaitForSeconds(5);
        door.Play("busdoor_Close");

    }
    IEnumerator bus_closedoor()
    {
        door.Play("busdoor_Close");
        yield return new WaitForSeconds(1);

    }
}
