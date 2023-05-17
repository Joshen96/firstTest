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
    public int animindex;

    public Npc_id NPC_id;
    [SerializeField]
    private UI_npc uiMenu = null; //컴포넌트 받기위해 드래그로 
    bool isAction = false;
    //public Camera Playercam;
    //public GameObject Playercamobj;
    Transform nowTranform;
    Animator animator;

    private void Awake()
    {
        animator = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
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
            NPCReset(this.gameObject.transform.GetChild(0).gameObject);
            talkindex = 0;
            lookindex = 0;
            animindex = 0;
        }
    }

    void Talk(int _id)
    {
       string talkData =  talkManager.GetTalk(_id, talkindex);
       Transform lookData = talkManager.GetLook(_id, lookindex);
        int animData = talkManager.GetAnim(_id, animindex);
        
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
        if (animData == 100)
        {
            animindex = 0;
        }
        uiMenu.transform.GetChild(0).gameObject.GetComponent<Text>().text = talkData;


        Debug.Log("테스트"+ animData);
        animator.SetInteger("state", animData);

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
        animindex++;
    }
    public void button_next_talk()
    {
        Talk(NPC_id.id);
    }
 
    public static void NPCReset(GameObject _body)
    {
        GameObject npc = _body.gameObject.transform.parent.gameObject;

        _body.transform.rotation = npc.transform.rotation;
        //_body.transform.position = npc.transform.position;
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
        dir.y = 0f;
        yield return this.gameObject.transform.GetChild(0).transform.rotation = Quaternion.Lerp(this.gameObject.transform.GetChild(0).transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);  
    }
}


