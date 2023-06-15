using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class animaltrigger : MonoBehaviour
{
   
    public Transform animals;
    public Transform cat;
    float scrPlayDist = 1.0f;

    // 피할 때의 회전 속도
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag == "Animals")
        {
           // Debug.Log("동물과의 만남");

        }

    }
    public void Update()
    {
        DebugDistance();
        float dist = CalcDistanceWithTarget();
        if (dist < scrPlayDist)
        {
            this.GetComponent<Catmove>().speed = 50f;
        }
        else
        {
            this.GetComponent<Catmove>().speed = 3f;
        }
    }
    private void DebugDistance()
    {
        
        Vector3 dirToTarget =
            cat.position - animals.transform.position;

        Color color = Color.white;

        if (scrPlayDist < dirToTarget.magnitude)
            color = Color.yellow;
        else
            color = Color.red;

        Debug.DrawLine(
            animals.transform.position,
            cat.position,
            color);
    }
    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            cat.position - animals.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            cat.position, animals.transform.position);

        return dist;
    }


}
