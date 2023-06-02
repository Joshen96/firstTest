using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Class1_Story : MonoBehaviour
{
    public GameObject npc1;
    Npc_id npc1_id;
    public Transform nextpos1;
    public Transform nextpos2;

    static JS_Class1_Story _instance = null;
    public static JS_Class1_Story Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        npc1_id = npc1.GetComponent<Npc_id>();
    }
    private void Start()
    {
        if (_instance == null)
            _instance = this;

    }

   

    public void openbackdoor1clear()
    {
        npc1_id.id=1001;
    }
    public void openfrontdoor1clear()
    {
        npc1_id.id = 1002;
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
