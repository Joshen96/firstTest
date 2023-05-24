using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_Traffic_PedestrianSpawner : MonoBehaviour
{
    public GameObject pedestianPrefab;
    public int pedestriansToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < pedestriansToSpawn)
        {
            GameObject obj = Instantiate(pedestianPrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<BC_NPC_Traffic_WaypointNavigator>().currentWaypoint = child.GetComponent<BC_NPC_Traffic_Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
