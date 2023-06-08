using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_Traffic_PedestrianSpawner : MonoBehaviour
{
    public GameObject[] pedestrianPrefabs;
    public int pedestriansToSpawn;
    public GameObject culpritPrefab; // 범인 프리팹 추가

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        bool culpritSpawned = false; // 범인 스폰 여부 체크용 변수

        while (count < pedestriansToSpawn)
        {
            GameObject prefab;

            if (!culpritSpawned && count == pedestriansToSpawn - 1)
            {
                // 마지막 NPC일 경우 범인 프리팹 사용
                prefab = culpritPrefab;
                culpritSpawned = true;
            }
            else
            {
                prefab = pedestrianPrefabs[Random.Range(0, pedestrianPrefabs.Length)];
            }

            GameObject obj = Instantiate(prefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount));
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
