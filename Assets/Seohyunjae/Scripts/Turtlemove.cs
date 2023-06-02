using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turtlemove : MonoBehaviour
{
    public Transform turtle;
    public Transform[] paths;
    public float speed = 0.5f;
    public int i = 0;
    // Start is called before the first frame update
    private void Start()
    {
        turtle.transform.position = paths[0].transform.position;
    }
    private void Update()
    {
        turtle.transform.position = Vector3.MoveTowards(turtle.transform.position, paths[i].transform.position, speed * Time.deltaTime);
        lookingPlayer(paths[i]);
        if (turtle.transform.position == paths[i].transform.position)
        {
            i++;
        }

        if (i >= paths.Length)
        {
            i = 0;
        }

    }
    public void lookingPlayer(Transform _nextpath)
    {
        Vector3 dir = _nextpath.transform.position - turtle.transform.position;
        turtle.gameObject.transform.rotation = Quaternion.Lerp(turtle.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

    }
}
