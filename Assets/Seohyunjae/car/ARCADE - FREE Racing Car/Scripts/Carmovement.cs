using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Carmovement : MonoBehaviour
{
    public GameObject car;
    

    public Transform Player;
    public Transform[] paths;
    public float speed = 1f;
    

    public int i = 0;
    public float scrPlayDist = 8f;

    public bool inplayer = false;
    public bool isaccord = false;
    public bool isStopcar = false;
    public bool isNoclick = false;
    public GameObject carui;
    
    

    private void Awake()
    {
        isStopcar = false;

    }
    private void Start()
    {
        car.transform.position = paths[0].transform.position;
    }
    private void Update()
    { 

        speed = car.gameObject.GetComponentInChildren<Car_Speed>().speed;
        DebugDistance();
       
        float dist = CalcDistanceWithTarget();
        
       
        if (dist < scrPlayDist&&!inplayer) 
        {

            isStopcar = true;
            if (!isNoclick)
            {
            carui.SetActive(true);
            }


        }

        else
        {
                       
            isNoclick = false;
            carui.SetActive(false);
            isStopcar= false;
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

   

    public void lookingPlayer(Transform _nextpath)
    {
        Vector3 dir = _nextpath.transform.position - car.transform.position;
        car.gameObject.transform.rotation = Quaternion.Lerp(car.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 5f);

    }
  
} 
