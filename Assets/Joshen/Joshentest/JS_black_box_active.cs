using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_black_box_active : MonoBehaviour
{
    [SerializeField]
    Transform resetPos;
    [SerializeField]
    GameObject BlackBoxCam;
    [SerializeField]
    GameObject BlackBoxPad;


    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.name== "Direct Interactor")
        {
            BlackBoxPad.SetActive(true);
        }
    }

    /*
    private void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.name == "Direct Interactor")
        {
            BlackBoxPad.SetActive(false);
            BlackBoxPad.transform.position = resetPos.position;
            BlackBoxPad.transform.rotation = resetPos.rotation;
        }
    }
  */



    public void detach_Cam_off()
    {

        BlackBoxCam.SetActive(false);
        BlackBoxPad.transform.position = resetPos.position;
        BlackBoxPad.transform.rotation = resetPos.rotation;
        BlackBoxPad.transform.localEulerAngles = new Vector3(0, 90f, 0);
        BlackBoxPad.SetActive(false);
        
    }

    public void grab_Cam_on()
    {

        BlackBoxCam.SetActive(true);
       

    }


    public void Handdown()
    {
        BlackBoxPad.SetActive(true);
    }


    public void Handup()
    {
        BlackBoxPad.SetActive(false);
    }

}
