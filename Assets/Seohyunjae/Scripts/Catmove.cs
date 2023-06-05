using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Catmove : MonoBehaviour
{

    public Transform cat;
    public Transform[] paths;
    public Transform Player;
    public Animator animator;
   

    


    public float speed = 1.5f;
    public float scrPlayDist = 8f;
    public int i = 0;
    private bool isclicked = false;


    // Start is called before the first frame update
    
    private void Start()
    {
        cat.transform.position = paths[0].transform.position;
        animator = GetComponent<Animator>();


    }
    public void Update()
    {

        
        float dist = CalcDistanceWithTarget();
        if (dist < scrPlayDist)
        {
            animator.SetBool("Clicked", !isclicked);
            transform.LookAt(Player.position);
            //catangleturn.transform.rotation = Quaternion.Euler(Vector3.right * 180f);
            //Debug.Log(Quaternion.Euler(Vector3.right * dist));


        }
        else
        {
            
            animator.SetBool("Clicked", isclicked);
            DebugDistance();
            cat.transform.position = Vector3.MoveTowards(cat.transform.position, paths[i].transform.position, speed * Time.deltaTime);
            lookingPlayer(paths[i]);
            if (cat.transform.position == paths[i].transform.position)
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
        Vector3 dir = _nextpath.transform.position - cat.transform.position;
        cat.gameObject.transform.rotation = Quaternion.Lerp(cat.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

    }
    private void DebugDistance()
    {
        Vector3 dirToTarget =
            Player.position - cat.transform.position;

        Color color = Color.white;

        if (scrPlayDist < dirToTarget.magnitude)
            color = Color.yellow;
        else
            color = Color.red;

        Debug.DrawLine(
            cat.transform.position,
            Player.position,
            color);
    }
    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            Player.position - cat.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            Player.position, cat.transform.position);

        return dist;
    }





}