using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misson_dontdestory : MonoBehaviour
{
    
    public void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        this.gameObject.transform.parent = player.transform;
        this.gameObject.transform.localPosition = Vector3.zero;
        //this.gameObject.transform.rotation = 


        var obj = FindObjectsOfType<Misson_dontdestory>();
        if (obj.Length == 1) DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);
        

    }

   
}
