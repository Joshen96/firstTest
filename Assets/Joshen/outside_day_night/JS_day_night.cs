using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JS_day_night : MonoBehaviour
{
    public Material night = null;
    public Material day = null;
    // Start is called before the first frame update
   


    public void dayOn()
    {
        RenderSettings.skybox = day;
    }
    public void nightOn()
    {
        RenderSettings.skybox = night;
    }
    
}
