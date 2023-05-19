using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Device;
using static UnityEngine.GraphicsBuffer;

public class Carmovement : MonoBehaviour
{
    public GameObject car;
    public GameObject Noparkingset;
    

    public Transform Player;
    public Transform[] paths;
    public float speed=1f;
    
    public int i = 0;
    public float scrPlayDist = 3f;
    public bool isStopcar = false;
    

    private void Awake()
    {
       
    }
    private void Start()
    {
        car.transform.position = paths[0].transform.position;
        
    }
    private void Update()
    {
        
        
        DebugDistance();
        float dist = CalcDistanceWithTarget();

        if (dist > scrPlayDist) 
        {
            isStopcar = false;
            car.transform.position = Vector3.MoveTowards(car.transform.position, paths[i].transform.position, speed * Time.deltaTime);
            //car.transform.LookAt(paths[i]);
            lookingPlayer(paths[i]);
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
            //�������߱�
        }

    }

    public void carMove()
    {
        car.transform.position = Vector3.MoveTowards(car.transform.position, paths[i].transform.position, speed * Time.deltaTime);

    }
    private void DebugDistance()
    {
        Vector3 dirToTarget =
            Player.position - car.transform.position;

        Color color = Color.white;
        if (scrPlayDist < dirToTarget.magnitude)
            color = Color.yellow;
        else
            color = Color.red;

        Debug.DrawLine(
            car.transform.position,
            Player.position,
            color);
    }
    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            Player.position - car.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            Player.position, car.transform.position);

        return dist;
    }
    private float CalcDistanceWithTarge2()
    {
        Vector3 dirToTarget =
            Noparkingset.transform.position - car.transform.position;
        float dist2 = dirToTarget.magnitude;

        dist2 = Vector3.Distance(
            Noparkingset.transform.position, car.transform.position);

        return dist2;
    }



    public void lookingPlayer(Transform _nextpath)
    {
        Vector3 dir = _nextpath.transform.position - car.transform.position;
        car.gameObject.transform.rotation = Quaternion.Lerp(car.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);


    }
  
} 
