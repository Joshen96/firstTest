using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class Npc : MonoBehaviour
{
    [SerializeField]
    TalkManager talkManager;
    public int talkindex;
    public int lookindex;
    public Npc_id NPC_id;
    [SerializeField]
    private UI_npc uiMenu = null; //컴포넌트 받기위해 드래그로 
    bool isAction = false;
    public Camera Playercam;
    //public GameObject Playercamobj;
    Transform nowTranform;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isAction)
        {
            Talk(NPC_id.id);

        }
        if (nowTranform !=null)
        {
            StartCoroutine(camMove(nowTranform));
        }
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiMenu.gameObject.SetActive(true);
            isAction = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Talk(NPC_id.id);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiMenu.gameObject.SetActive(false);
            uiMenu.transform.GetChild(0).gameObject.GetComponent<Text>().text = " ";
            CamReset(Playercam);
            talkindex = 0;
            lookindex = 0;

        }
    }

    void Talk(int _id)
    {
       string talkData =  talkManager.GetTalk(_id, talkindex);
       Transform lookData = talkManager.GetLook(_id, lookindex);
        
        if(talkData == null) 
        {
            talkindex = 0;
            
            uiMenu.gameObject.SetActive(false);
            isAction = false;
            return;
        }
        if(lookData == null)
        {
            lookindex = 0;

        }
        uiMenu.transform.GetChild(0).gameObject.GetComponent<Text>().text = talkData;

        /*
        Vector3 delta = lookData.position - Playercam.transform.position;
        Quaternion rot = Quaternion.LookRotation(delta);
        Playercam.transform.rotation = Quaternion.Slerp(Playercam.transform.rotation, rot, 5 * Time.deltaTime);
        */

        //StartCoroutine(camMove(lookData));
        nowTranform = lookData;
        //Playercam.transform.LookAt(lookData);
        //Playercam.transform.rotation.z = 0;

        lookindex++;
        talkindex++;

    }
    public void button_next_talk()
    {
        Talk(NPC_id.id);
    }
 
    public static void CamReset(Camera _Playercam)
    {
        GameObject cam = _Playercam.gameObject.transform.parent.gameObject;

        _Playercam.transform.rotation = cam.transform.rotation;
        _Playercam.transform.position = cam.transform.position;
    }

    IEnumerator camMove(Transform _lookData)
    {
        if (_lookData == null)
        {
            yield return null;
        }
        Vector3 dir = _lookData.transform.position - Playercam.transform.position;


        //Playercam.transform.rotation = Quaternion.Lerp(Playercam.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
        //Playercam.transform.rotation = Quaternion.Lerp(Playercam.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
        yield return Playercam.transform.rotation = Quaternion.Lerp(Playercam.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);  
    }
}


