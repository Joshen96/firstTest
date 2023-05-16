using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmovement : MonoBehaviour
{
    public GameObject car;
    public Transform[] paths;
    public float speed = 10f;
    public int i = 0;

    private void Start()
    {
        car.transform.position = paths[0].transform.position;

    }
    private void Update()
    {

        car.transform.position = Vector3.MoveTowards(car.transform.position, paths[i].transform.position, speed * Time.deltaTime);
        car.transform.LookAt(paths[i]);
        if (car.transform.position == paths[i].transform.position)
        {
         i++;
        }

        if (i>=paths.Length)
        {
            i= 0;
        }
       
    }


    public void carMove()
    {
        car.transform.position = Vector3.MoveTowards(car.transform.position, paths[i].transform.position, speed * Time.deltaTime);
    }

} 
