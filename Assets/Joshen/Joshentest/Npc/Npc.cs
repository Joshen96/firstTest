using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    private UI_npc uiMenu = null; //컴포넌트 받기위해 드래그로 

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


