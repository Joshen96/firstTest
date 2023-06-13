using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_artroom_button : MonoBehaviour
{
    public GameObject normal_pictures;
    public GameObject horror_pictures;
    public Material nomalSky = null;
    public Material horrorSky = null;
    public bool isPP = false;
    public JS_sky_system sky;

    private void Start()
    {
        sky = this.GetComponent<JS_sky_system>();
    }

    public void callPostProcess()
    {
        if (isPP == false)
        {
            if (!Mission_imfo.isFindingEasteregg) Mission_imfo.isFindingEasteregg = true;
            sky.enabled = true;
            RenderSettings.skybox = horrorSky;
            this.gameObject.SetActive(true);
            horror_pictures.SetActive(true);
            normal_pictures.SetActive(false);
            isPP = true;
        }
        else
        {
            sky.enabled = false;
            RenderSettings.skybox = nomalSky;
            this.gameObject.SetActive(false);
            horror_pictures.SetActive(false);
            normal_pictures.SetActive(true);
            isPP = false;
        }
    }



}

