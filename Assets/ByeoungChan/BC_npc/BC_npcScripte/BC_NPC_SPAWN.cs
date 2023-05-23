using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_SPAWN : MonoBehaviour
{
    public Transform SpawnPoint;
    public float nextSpawn = 2f;
    public float SpawnRate = 5f;
    public GameObject NPC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + SpawnRate;
            Instantiate(NPC, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }
}
