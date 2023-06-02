using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_REMOVENPC_DISTANCE : MonoBehaviour
{
    [SerializeField]
    private float hideDistance = 150f;
    [SerializeField]
    private float showDistance = 100f;

    private GameObject GetPlayer()
    {
       // if (!player) player = GameObject.FindGameObjectWithTag("Player").transform.root.gameObject;
        if (!player) player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }

    private GameObject player = null;

    private bool isHidden = false;

    // Update is called once per frame
    private void Update()
    {
        var player = GetPlayer();
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance<showDistance)
        {
            if (isHidden)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                GetComponent<BC_NPC_Random_Animation>().enabled = true;
                isHidden = false;
            }
        }
        else if(distance > hideDistance)
        {
            if (!isHidden)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                GetComponent<BC_NPC_Random_Animation>().enabled = false;
                isHidden = true;
            }
        }
    }
}
