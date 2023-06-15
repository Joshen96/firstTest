using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargateStop : MonoBehaviour
{
    public float carspeed = 3f;
    [SerializeField]
    GameObject pivot;
    private Transform tr;
    private Transform tr2 ;

    private void Start()
    {
        tr = pivot.gameObject.transform;
        
    }
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.tag == "Car")
        {
            _other.gameObject.GetComponent<Car_Speed>().speed=0f;
            //Debug.Log("Â÷°¨Áö");

            StartCoroutine(Rotation());
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Car")
        {
            StartCoroutine(delaycarmove(_other.gameObject));
           // Debug.Log("Â÷¶³¾îÁü");
            
        }
    }
    IEnumerator delaycarmove(GameObject _other)
    {
        yield return new WaitForSeconds(1f);
        _other.gameObject.GetComponent<Car_Speed>().speed = carspeed;
    }

    IEnumerator Rotation()
    {
        StartCoroutine(iRotationup(90f));
        yield return new WaitForSeconds(5f);

        
       yield return StartCoroutine(iRotationdown(0f));

    }
    IEnumerator iRotationup(float targetAngle)
    {
        float st = tr.eulerAngles.z;
        float er = targetAngle;

        float t = 0f;

        while (t < 2f)
        {
            t += 1f * Time.deltaTime;
            float speed = t;
            float zRotation = Mathf.Lerp(st, er, speed) % 360.0f;

            //tr.eulerAngles = new Vector3(-xRotation, tr.eulerAngles.y, tr.eulerAngles.z);
            tr.eulerAngles = new Vector3(tr.eulerAngles.x, tr.eulerAngles.y, zRotation);

            // Debug.Log(yRotation + " " + transform.eulerAngles.y);

            yield return null;
        }
    }
 
    IEnumerator iRotationdown(float targetAngle)
    {
        float st = tr.eulerAngles.z;
        float er = targetAngle;

        float t = 0f;

        while (t < 2f)
        {
            t += 1f * Time.deltaTime;
            float speed = t;
            float zRotation = Mathf.Lerp(90, 0, speed) % 360.0f;

            //Debug.Log(zRotation);
            //tr.eulerAngles = new Vector3(-xRotation, tr.eulerAngles.y, tr.eulerAngles.z);
            tr.eulerAngles = new Vector3(tr.eulerAngles.x, tr.eulerAngles.y, zRotation);

            // Debug.Log(yRotation + " " + transform.eulerAngles.y);

            yield return null;
        }
    }
    
}
