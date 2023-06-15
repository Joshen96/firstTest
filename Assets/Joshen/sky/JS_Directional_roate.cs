using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Directional_roate : MonoBehaviour
{
    Transform tr;
    
    float nightAngle = 265f;
    float dayAngle = 50f;
    void Start()
    {
        tr = this.gameObject.transform;
    }
    


    public void onday()
    {
        this.GetComponent<Light>().enabled = true;
        StartCoroutine(dayRotation());
    }
    public void onnight()
    {
        
        StartCoroutine(nightRotation());
    }

    IEnumerator nightRotation()
    {
        float st = tr.eulerAngles.x;
        float er = nightAngle;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime*0.5f;
            float speed = t;
            float xRotation = Mathf.LerpAngle(st, er, speed)%360;
           // Debug.Log(xRotation);
            tr.eulerAngles = new Vector3(xRotation, tr.eulerAngles.y, tr.eulerAngles.z);
            // Debug.Log(yRotation + " " + transform.eulerAngles.y);

            

        }
        yield return new WaitForSeconds(2f);
        this.GetComponent<Light>().enabled = false;

    }
    IEnumerator dayRotation()
    {
        float st = tr.eulerAngles.x;
        float er = dayAngle;
        
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime*0.5f;
            float speed = t;
            float xRotation = Mathf.LerpAngle(st, er, speed)%360;

            tr.eulerAngles = new Vector3(xRotation, tr.eulerAngles.y, tr.eulerAngles.z);
            // Debug.Log(yRotation + " " + transform.eulerAngles.y);

            yield return null;
        }
    }
}

