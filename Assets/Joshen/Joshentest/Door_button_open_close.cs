using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_button_open_close : MonoBehaviour
{
    public GameObject button_open;
    public GameObject button_close;

   public void openbutton()
    {
        button_open.SetActive(false);
        button_close.SetActive(true);
    }
   public void closebutton()
    {
        button_close.SetActive(false);
        button_open.SetActive(true);
    }
}
