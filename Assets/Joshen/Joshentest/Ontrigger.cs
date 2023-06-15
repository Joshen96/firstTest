using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger: MonoBehaviour
{
    public static bool isPlayground;
    public static bool isClass1;
    public static bool isClass2;


    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag=="Zone")
        {
            if (_other.gameObject.name == "ground_collider")
            {
                isPlayground = true;
               // Debug.Log("여기는 운동장 입니다");
            }
            if(_other.gameObject.name == "class1_collider")
            {
                isClass1 = true;
                //Debug.Log("여기는 교실1 입니다");
            }
           
        }
    }
    private void OnTriggerExit(Collider _other)
    {

        if (_other.gameObject.tag == "Zone")
        {
            if (_other.gameObject.name == "ground_collider")
            {
                isPlayground = false;
                //Debug.Log("운동장 에서 나갑니다");
            }
            if (_other.gameObject.name == "class1_collider")
            {
                isClass1 = false;
                //Debug.Log("교실 에서 나갑니다");
            }
        }
    }
}
