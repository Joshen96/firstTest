using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Keysoket : MonoBehaviour
{
    [SerializeField]
    GameObject openUI;
    [SerializeField]
    GameObject lockUI;
 

    private void Start()
    {
        openUI.SetActive(false);
        lockUI.SetActive(true);
    }

   
    public void onon()
    {
        openUI.SetActive(true);
        lockUI.SetActive(false);
    }
    public void lockdoor()
    {
        openUI.SetActive(false);
        lockUI.SetActive(true);
    }

}
