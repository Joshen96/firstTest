using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_bus_GetOn_Ani : MonoBehaviour
{
    public Animator playerani;
    public GameObject Player;

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
    }



}
