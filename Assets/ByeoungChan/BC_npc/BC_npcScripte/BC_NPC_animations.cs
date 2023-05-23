using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_animations : MonoBehaviour
{
    private Animator anim;

    private IEnumerator Start()
    {
        anim = GetComponent<Animator>();
        while(true)
        {
            yield return new WaitForSeconds(3);


            anim.SetInteger("playerindex", Random.Range(0, 1));
            anim.SetTrigger("phone");

            anim.SetInteger("walkindex", Random.Range(0, 3));
            anim.SetTrigger("walk");

            

        }
    }
}
