 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JS_day_night : MonoBehaviour
{
    public Material night = null;
    public Material day = null;
    public GameObject dayLight;
    public GameObject nightLight;

    public Color dayfog;
    public Color nightfog;
    // Start is called before the first frame update
   


    public void dayOn()
    {
        RenderSettings.skybox = day;
        //RenderSettings.fogColor = dayfog;
        RenderSettings.ambientLight = dayfog;
        RenderSettings.fogDensity = 0;

    }
    public void nightOn()
    {
        RenderSettings.skybox = night;
        //RenderSettings.fogColor = nightfog;
        RenderSettings.ambientLight = nightfog;
        RenderSettings.fogDensity = 0.001f;
    }
    
}
