using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carinuiyes : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;
    public GameObject car;
    public GameObject carinui;
    public GameObject getoff;
    // Start is called before the first frame update
    public void carinyes()
    {
        
        Caruiclick.carin_bool = false;
        camera.SetActive(false);

        player.transform.position = car.transform.position + new Vector3(-2f, 1f, 0);
        player.SetActive(true);
        carinui.SetActive(false);
    }
    public void carInNO()
    {
        getoff.SetActive(false);
        Invoke("carinuireutrn", 3f);
    }
    public void carinuireutrn()
    {
        getoff.SetActive(true);
    }
}
