using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;
using Autodesk.Fbx;

public class Carinuiyes : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;
    public GameObject car;
    public GameObject carinui;
    public GameObject getoff;
    public GameObject busoutpositon;
    // Start is called before the first frame update
    Carmovement carmovement;
    private void Awake()
    {
        carmovement = GetComponentInParent<Carmovement>();
    }
    public void carinyes()
    {
        
        Caruiclick.carin_bool = false;
        camera.SetActive(false);



        player.transform.position = busoutpositon.transform.position;

        player.SetActive(true);
        carinui.SetActive(false);
        carmovement.inplayer = false;
        
        player.transform.parent = null;

        //플레이어 텔레포트기능과 이동 활성화부분

        player.GetComponent<TeleportationProvider>().enabled = true; //텔포허용
        player.GetComponent<DynamicMoveProvider>().enabled = true;
        player.GetComponentsInChildren<GrabMoveProvider>()[0].enabled = true;
        player.GetComponentsInChildren<GrabMoveProvider>()[1].enabled = true;

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
