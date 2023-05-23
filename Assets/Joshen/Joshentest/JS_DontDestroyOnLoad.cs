using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        var objs = FindObjectsOfType<JS_DontDestroyOnLoad>();
        if(objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
