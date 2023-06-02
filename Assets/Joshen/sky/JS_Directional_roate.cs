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
        tr = gameObject.transform;
    }
    private void Update()
    {

    }


    public void onday()
    {
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

        while (t < 3f)
        {
            t += Time.deltaTime;
            float speed = t;
            float xRotation = Mathf.Lerp(st, er, speed)%360;

            tr.eulerAngles = new Vector3(xRotation, tr.eulerAngles.y, tr.eulerAngles.z);
            // Debug.Log(yRotation + " " + transform.eulerAngles.y);

            yield return null;
        }
    }
    IEnumerator dayRotation()
    {
        float st = tr.eulerAngles.x;
        float er = dayAngle;

        float t = 0f;

        while (t < 3f)
        {
            t += Time.deltaTime;
            float speed = t;
            float xRotation = Mathf.Lerp(st, er,    speed)%360;

            tr.eulerAngles = new Vector3(xRotation, tr.eulerAngles.y, tr.eulerAngles.z);
            // Debug.Log(yRotation + " " + transform.eulerAngles.y);

            yield return null;
        }
    }
}

