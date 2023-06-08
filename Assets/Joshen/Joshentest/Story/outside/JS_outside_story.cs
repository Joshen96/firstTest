using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_outside_story : MonoBehaviour
{
    public GameObject npc1;
    Npc_id npc1_id;
    public Transform nextpos1;
    public Transform nextpos2;

    

    private void Awake()
    {
        npc1_id = npc1.GetComponent<Npc_id>();
    }
  



    public void nexttalk1()
    {
        npc1_id.id = 101;
    }
    public void nexttalk2()
    {
        npc1_id.id = 102;
    }

    public void nextgo1()
    {
        npc1.transform.position = nextpos1.transform.position;
    }
    public void nextgo2()
    {
        npc1.transform.position = nextpos2.transform.position;
    }
}
