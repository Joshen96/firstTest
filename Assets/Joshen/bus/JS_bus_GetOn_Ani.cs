using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class JS_bus_GetOn_Ani : MonoBehaviour
{
    public Animator playerani;
    public GameObject Player;


    public Carmovement carmove;
    public void Geton()
    {
        StartCoroutine(Geton_co());
    }
    IEnumerator Geton_co()
    {
        yield return new WaitForSeconds(0.5f);

        playerani.Play("businplay");


    }
    public void Getoff()
    {
        StartCoroutine(Getoff_co());
    }
    IEnumerator Getoff_co()
    {
        yield return new WaitForSeconds(0.5f);

        playerani.Play("busoutplay");


    }
    public void detach()
    {
        Player.transform.parent = null;
        Player.GetComponent<TeleportationProvider>().enabled = true; //텔포허용
        Player.GetComponent<DynamicMoveProvider>().enabled = true;
        Player.GetComponentsInChildren<GrabMoveProvider>()[0].enabled = true;
        Player.GetComponentsInChildren<GrabMoveProvider>()[1].enabled = true;
    }

    public void deleyGobus()
    {
        carmove.inplayer = true;
    }


}
