using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turtlemove : MonoBehaviour
{

    public Transform turtle;
    public Transform[] paths;
    public Transform Player;
    public Animator animator;

    public string[] animationStates;
    public float speed = 1.5f;
    public float scrPlayDist = 2f;
    public int i = 0;
    private bool isclicked = false;

    // Start is called before the first frame update

    private void Start()
    {
        turtle.transform.position = paths[0].transform.position;
        animator = GetComponent<Animator>();

    }
    public void Update()
    {

        float dist = CalcDistanceWithTarget();
        if (dist < scrPlayDist)
        {
            animator.enabled = false;
            //speed = 3.0f;
            //transform.LookAt(Player.position);
            //turtleangleturn.transform.rotation = Quaternion.Euler(Vector3.right * 180f);
            //Debug.Log(Quaternion.Euler(Vector3.right * dist));
            
        }
        else
        {
            animator.enabled = true;
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
    }
    public void lookingPlayer(Transform _nextpath)
    {
        Vector3 dir = _nextpath.transform.position - turtle.transform.position;
        turtle.gameObject.transform.rotation = Quaternion.Lerp(turtle.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

    }
     
    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            Player.position - turtle.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            Player.position, turtle.transform.position);

        return dist;
    }

}