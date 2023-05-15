using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField]
    TalkManager talkManager;
    public int talkindex;
    public Npc_id NPC_id;
    [SerializeField]
    private UI_npc uiMenu = null; //컴포넌트 받기위해 드래그로 
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiMenu.gameObject.SetActive(true);
            Talk(NPC_id.id);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiMenu.gameObject.SetActive(false);
        }
    }

    void Talk(int _id)
    {
       string talkData =  talkManager.GetTalk(_id, talkindex);
        uiMenu.transform.GetChild(0).gameObject.GetComponent<Text>().text = talkData;

    }
}


