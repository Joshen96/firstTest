using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    private UI_npc uiMenu = null; //������Ʈ �ޱ����� �巡�׷� 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiMenu.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiMenu.gameObject.SetActive(false);
        }
    }
}


