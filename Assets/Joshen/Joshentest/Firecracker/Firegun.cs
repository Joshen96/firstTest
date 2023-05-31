using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firegun : MonoBehaviour
{
    GameObject fire = null;
    [SerializeField]
    private GameObject[] fireprefabs = null;
    [SerializeField]
    private Transform firepoint = null;


    public void firework()
    {
        foreach (GameObject fireprefab in fireprefabs)
        {
            GameObject fires = Instantiate(fireprefab);
            fires.transform.position = firepoint.position;
            fires.transform.rotation = firepoint.rotation;
        }
    }
}
