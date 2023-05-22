using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Caruiclick : MonoBehaviour
{
    public GameObject carcamera;
    public GameObject carui;
    public GameObject player;
    public GameObject car;
    public Transform carin_tranform;

    public static bool carin_bool;

    
    //public GameObject camera;
    // Start is called before the first frame update
   

    public void yesOnClick()
    {
        carin_bool= true;
        carcamera.SetActive(true);
        Debug.Log("차량ui클릭");
        Debug.Log(car.transform.position);
        carui.SetActive(false);
        player.SetActive(false);
        player.transform.position = carin_tranform.transform.position;
        
        //player.transform.position = car.transform.position + new Vector3(4f, 0, 0);
    }
    public void noOnClick() 
    {
        carcamera.SetActive(false);
        Carmovement carmovement = this.GetComponentInParent<Carmovement>();
        carmovement.isNoclick = true;
        carui.SetActive(false);
        player.transform.position = car.transform.position + new Vector3(-2f, 2f, 0);
        player.SetActive(true);

    }
}
