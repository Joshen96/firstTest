using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoveMove : MonoBehaviour
{
    public Transform Dove;
    public Transform[] paths;
    public float speed = 1.5f;

    public int i = 0;
    // Start is called before the first frame update
    private void Start()
    {
        Dove.transform.position = paths[0].transform.position;
    }
    private void Update()
    {
        Dove.transform.position = Vector3.MoveTowards(Dove.transform.position, paths[i].transform.position, speed * Time.deltaTime);
        lookingPlayer(paths[i]);
        if (Dove.transform.position == paths[i].transform.position)
        {
            i++;
        }

        if (i >= paths.Length)
        {
            i = 0;
        }

    }
    public void lookingPlayer(Transform _nextpath)
    {
        Vector3 dir = _nextpath.transform.position - Dove.transform.position;
        Dove.gameObject.transform.rotation = Quaternion.Lerp(Dove.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

    }
}