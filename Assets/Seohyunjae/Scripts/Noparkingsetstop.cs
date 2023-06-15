using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Noparkingsetstop : MonoBehaviour
{
    public GameObject car;
    public GameObject noparkingset;
    public Transform[] paths;


    public float scrPlayDist = 25f;
    public bool isStopcar = false;
    public int i = 0;
    public float speed = 1f;

    private void Update()
    {
        CalcDistanceWithTarget();
        DebugDistance();
        float dist = CalcDistanceWithTarget();
        //Debug.Log(dist);

        if (dist > scrPlayDist)
        {
            isStopcar = false;
            car.transform.position = Vector3.MoveTowards(car.transform.position, paths[i].transform.position, speed * Time.deltaTime);
            //car.transform.LookAt(paths[i]);
            
            if (car.transform.position == paths[i].transform.position)
            {
                i++;
            }

            if (i >= paths.Length)
            {
                i = 0;
            }
        }
        else
        {
            isStopcar = true;
            //¹ÙÄû¸ØÃß±â
        }

    }
    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            noparkingset.transform.position - car.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            noparkingset.transform.position, car.transform.position);

        return dist;
    }
    private void DebugDistance()
    {
        Vector3 dirToTarget =
            noparkingset.transform.position - car.transform.position;

        Color color = Color.white;
        if (scrPlayDist < dirToTarget.magnitude)
            color = Color.yellow;
        else
            color = Color.red;

        Debug.DrawLine(
            car.transform.position,
            noparkingset.transform.position,
            color);
    }
     

}
