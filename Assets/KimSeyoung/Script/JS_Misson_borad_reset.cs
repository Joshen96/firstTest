using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Misson_borad_reset : MonoBehaviour
{
    [SerializeField]
    Transform resetPos;
    
    [SerializeField]
    GameObject Missionboard;


    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.name == "Direct Interactor")
        {
            Missionboard.SetActive(true);
        }
    }



    public void detach_Missionboard_off()
    {


        Missionboard.transform.position = resetPos.position;
        Missionboard.transform.rotation = resetPos.rotation;
        Missionboard.transform.localEulerAngles = new Vector3(0, 90f, 0);
        Missionboard.SetActive(false);

    }

   


    public void Handdown()
    {
        Missionboard.SetActive(true);
    }


    public void Handup()
    {
        Missionboard.SetActive(false);
    }

}
