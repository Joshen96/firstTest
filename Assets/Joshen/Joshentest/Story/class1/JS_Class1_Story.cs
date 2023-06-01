using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Class1_Story : MonoBehaviour
{
   public Npc_id npc1;

    static JS_Class1_Story _instance = null;
    public static JS_Class1_Story Instance()
    {
        return _instance;
    }

    private void Start()
    {
        if (_instance == null)
            _instance = this;
    }

   

    public void opendoorclear()
    {
        npc1.id=1001;
    }





    
    
}
