using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BC_NPC_AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
         
    
}
