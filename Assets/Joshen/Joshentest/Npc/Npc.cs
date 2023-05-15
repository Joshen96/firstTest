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
    public Npc_id NPC_id;
    [SerializeField]
    private UI_npc uiMenu = null; //컴포넌트 받기위해 드래그로 
    bool isAction = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isAction)
        {
            Talk(NPC_id.id);

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
        }
    }

    void Talk(int _id)
    {
       string talkData =  talkManager.GetTalk(_id, talkindex);

        if(talkData == null) 
        {
            talkindex = 0;
            uiMenu.gameObject.SetActive(false);
            isAction = false;
            return;
        }
        uiMenu.transform.GetChild(0).gameObject.GetComponent<Text>().text = talkData;
        talkindex++;

    }
    public void button_next_talk()
    {
        Talk(NPC_id.id);
    }
}


