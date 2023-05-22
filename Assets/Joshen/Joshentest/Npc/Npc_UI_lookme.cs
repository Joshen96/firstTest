using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_UI_lookme : MonoBehaviour
{
    public GameObject playerobj;



    // Update is called once per frame
    void Update()
    {
        lookingPlayer();


    }


    public void lookingPlayer()
    {
        Vector3 dir = this.transform.position - playerobj.transform.position;
       
        this.gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
        

    }
    IEnumerator camMove(Transform _lookData)
    {
        if (_lookData == null)
        {
            yield return null;
        }
        //Vector3 dir = _lookData.transform.position - this.transform.position;
        Vector3 dir = this.transform.position - _lookData.transform.position;


        //Playercam.transform.rotation = Quaternion.Lerp(Playercam.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
        //Playercam.transform.rotation = Quaternion.Lerp(Playercam.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
        //dir.y = 0f;
        yield return this.gameObject.transform.GetChild(0).transform.rotation = Quaternion.Lerp(this.gameObject.transform.GetChild(0).transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
    }
}
