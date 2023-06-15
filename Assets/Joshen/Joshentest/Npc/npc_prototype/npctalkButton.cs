using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npctalkButton : MonoBehaviour
{
    [SerializeField]
    public static bool isclick = false;


    public delegate void Callback();

    private Callback callback = null;
    
    
    public void inclick()
    {
        //Debug.Log("Å¬¸¯");
        isclick = true;
        //callback();
    }
    public void outclick() {
        isclick = false;
    }
    public void SetCallback(Callback cal)
    {
        callback = cal;
    }
}
