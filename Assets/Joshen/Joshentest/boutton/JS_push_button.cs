using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JS_push_button : MonoBehaviour
{
  
    [SerializeField]
    private bool _isPressed;
    
    public UnityEvent onPressed, onReleased;



    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.name == "tirrger")
        {
            
            _isPressed = true;
            Pressed();
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.name == "tirrger")
        {
            
            _isPressed = false;
            Released();
        }

    }

    /*
    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;


     if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }
    */


    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        //Debug.Log("´­¸²");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        //Debug.Log("¶¼Áü");

    }
}
