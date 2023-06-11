using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_outside_light : MonoBehaviour
{
    public GameObject allLight;

    public void NightonLight()
    {
        allLight.gameObject.SetActive(true);
    }
    public void DayoffLight()
    {
        allLight.gameObject.SetActive(false);
    }

}
