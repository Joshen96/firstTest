using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground_sy : MonoBehaviour
{
    public bool isComeInPlayground = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isComeInPlayground = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isComeInPlayground = false;
        }
    }
}
