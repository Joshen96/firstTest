using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Birdmove : MonoBehaviour
{
    public Transform bird;
    public Transform[] paths;
    public float speed = 1.5f;
    public int i = 0;
    // Start is called before the first frame update
    private void Start()
    {
        bird.transform.position = paths[0].transform.position;
    }
    private void Update()
    {
        bird.transform.position = Vector3.MoveTowards(bird.transform.position, paths[i].transform.position, speed * Time.deltaTime);
        lookingPlayer(paths[i]);
        if (bird.transform.position == paths[i].transform.position)
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
        Vector3 dir = _nextpath.transform.position - bird.transform.position;
        bird.gameObject.transform.rotation = Quaternion.Lerp(bird.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

    }
}