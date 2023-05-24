using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BC_NPC_AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    

    public GameObject PATH;
    public GameObject NPC;
    private Transform[] PathPoints;

    public float minDistance = 10;

    public int index = 0;
    public int endiex = 0;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        PathPoints = new Transform[PATH.transform.childCount];
        for(int i = 0; i < PathPoints.Length; i++)
        {
            PathPoints[i] = PATH.transform.GetChild(i);
        }
       
    }

    private void Update()
    {
        roam();
    }

    

    private void roam()
    {

        if(Vector3.Distance(transform.position ,PathPoints[index].position) < minDistance)
        {
            if (index < PathPoints.Length)
            {
                
                index += 1;
                
            }
            if(index >= PathPoints.Length)
            {
                Destroy(NPC);
                return;
            }
            //if(endiex > PathPoints.Length)
            //{
            //    Destroy(NPC);
            //}



        }
        
        gonpc(index);


       // animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
    }

    public void gonpc(int _index)
    {
       
        agent.SetDestination(PathPoints[index].position); //¿Ãµø
      
    }
}
