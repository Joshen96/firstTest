using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class JS_sky_system : MonoBehaviour
{
    [SerializeField]
    float degree;
    //[SerializeField]
    //float light;

    void Start()
    {
        degree = 0f;

    }
    // Update is called once per frame
    void Update()
    {
        degree += Time.deltaTime;

        if (degree >= 360)
            degree = 0;

        RenderSettings.skybox.SetFloat("_Rotation", degree);     
    }
}
