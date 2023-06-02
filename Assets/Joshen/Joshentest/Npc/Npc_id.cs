using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_id : MonoBehaviour
{
    public int id;


    public void nextTalk()
    {
        id += 1;
    }
}
