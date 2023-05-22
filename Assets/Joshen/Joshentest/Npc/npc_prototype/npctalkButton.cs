using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npctalkButton : MonoBehaviour
{
    [SerializeField]
    public static bool isclick = false;
    public void inclick()
    {
        isclick = true;
    }
    public void outclick() {
        isclick = false;
    }
}
