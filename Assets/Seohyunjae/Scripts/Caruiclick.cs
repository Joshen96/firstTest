using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Caruiclick : MonoBehaviour
{
    public GameObject carcamera;
    public GameObject carui;
    public GameObject player;
    //public GameObject camera;
    // Start is called before the first frame update
   
    public void yesOnClick()
    {
        carcamera.SetActive(true);
        Debug.Log("123");
        carui.SetActive(false);
        player.SetActive(false);
        
    }
    public void noOnClick() 
    {
        carcamera.SetActive(false);
        carui.SetActive(false);
        player.SetActive(true);
    }
}
