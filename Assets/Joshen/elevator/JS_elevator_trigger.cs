using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_elevator_trigger : MonoBehaviour
{
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
