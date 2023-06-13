using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class JS_sky_system : MonoBehaviour
{
    [SerializeField]
    float degree;
    public float speed=1f;
    //[SerializeField]
    //float light;

    void Start()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 0f);
        degree = 0f;

    }
    // Update is called once per frame
    void Update()
    {
        degree += Time.deltaTime*speed;

        if (degree >= 360)
            degree = 0;

        RenderSettings.skybox.SetFloat("_Rotation", degree);     
    }
}
