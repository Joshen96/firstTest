using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Caruiclick : MonoBehaviour
{

    public GameObject carcamera;
    public GameObject carui;
    public GameObject player;
    public GameObject car;
    public GameObject carin_tranform;
    public GameObject carinui;

    public static bool carin_bool;

    Carmovement carmovement;
    //public GameObject camera;
    // Start is called before the first frame update

    private void Awake()
    {
        carmovement = GetComponentInParent<Carmovement>();
    }


    public void yesOnClick()
    {
        //Debug.Log(123);
        carin_bool = true;
        //carcamera.SetActive(true);
       // Debug.Log("����uiŬ��");
       // Debug.Log(car.transform.position);
        carui.SetActive(false);
        //player.SetActive(false);

        player.transform.parent = carin_tranform.transform; //�ڽ����� ������ ž�½���
        player.transform.position = carin_tranform.transform.position;
        player.transform.rotation = carin_tranform.transform.rotation;





        //�÷��̾�ž����

        //�÷��̾� �̵��ϰ� ��������
        player.GetComponent<TeleportationProvider>().enabled = false; //��������
        player.GetComponent<DynamicMoveProvider>().enabled = false;
        player.GetComponentsInChildren<GrabMoveProvider>()[0].enabled = false;
        player.GetComponentsInChildren<GrabMoveProvider>()[1].enabled = false;



        carinui.SetActive(true);



        //player.transform.position = car.transform.position + new Vector3(4f, 0, 0);
    }
    public void noOnClick()
    {

        carcamera.SetActive(false);
        Carmovement carmovement = this.GetComponentInParent<Carmovement>();
        carmovement.isNoclick = true;
        carui.SetActive(false);
        //carmovement.inplayer = false;
        //player.transform.position = car.transform.position + new Vector3(-2f, 2f, 0);
        //player.transform.parent = null;
        //player.SetActive(true);

    }
}


   
