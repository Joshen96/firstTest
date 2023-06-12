using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_elevator_button : MonoBehaviour
{
    public Animator elevator;
    public AudioSource sound;
    public bool isup= false;
    public bool isdown= true;

    private void Start()
    {
        isup = false;
        isdown = true;


    }
    public void upElevator()
    {
        if (isdown)
        {
            StartCoroutine(elevator_up_co());
            sound.Play();
        }
    }

    public void downElevator() 
    {
        if (isup)
        {
            sound.Play();
            StartCoroutine(elevator_down_co());
        }
        
    }
    IEnumerator elevator_up_co()
    {
        elevator.Play("up");
        yield return new WaitForSeconds(20);
        isup = true;
        isdown = false;
      

    }
    IEnumerator elevator_down_co()
    {
        elevator.Play("down");
        yield return new WaitForSeconds(20);
        isup = false;
        isdown = true;


    }

}
