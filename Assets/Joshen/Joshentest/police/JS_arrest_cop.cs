using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_arrest_cop : MonoBehaviour
{
    public Npc_id police;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
        police.id = 201;
    }
}
