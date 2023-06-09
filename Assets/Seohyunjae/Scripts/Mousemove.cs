using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousemove : MonoBehaviour
{

    public Transform mouse;
    public Transform[] paths;
    public Transform Player;
    public Animator animator;


    public string[] animationStates;
    public float speed = 2.5f;
    public float scrPlayDist = 3f;
    public int i = 0;
    private bool isclicked = false;
    private bool aniselect = false;


    // Start is called before the first frame update

    private void Start()
    {
        mouse.transform.position = paths[0].transform.position;
        animator = GetComponent<Animator>();

        if (animator == null || animationStates.Length == 0)
            return;


    }
    public void Update()
    {

        float dist = CalcDistanceWithTarget();
        if (dist < scrPlayDist)
        {
            //animator.SetBool("Spin", !isclicked);
            transform.LookAt(Player.position);
            //mouseangleturn.transform.rotation = Quaternion.Euler(Vector3.right * 180f);
            //Debug.Log(Quaternion.Euler(Vector3.right * dist));
            if (!aniselect)
            {
                PlayRandomAnimation();
            }
            animator.Play("Entry");

        }
        else
        {
            aniselect = false;
            animator.Play("Walk");


            mouse.transform.position = Vector3.MoveTowards(mouse.transform.position, paths[i].transform.position, speed * Time.deltaTime);
            lookingPlayer(paths[i]);
            if (mouse.transform.position == paths[i].transform.position)
            {
                i++;
            }

            if (i >= paths.Length)
            {
                i = 0;
            }
        }
    }
    public void lookingPlayer(Transform _nextpath)
    {
        Vector3 dir = _nextpath.transform.position - mouse.transform.position;
        mouse.gameObject.transform.rotation = Quaternion.Lerp(mouse.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

    }

    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            Player.position - mouse.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            Player.position, mouse.transform.position);

        return dist;
    }

    private void PlayRandomAnimation()
    {

        if (animator != null && animationStates.Length > 0)
        {
            int randomIndex = Random.Range(0, animationStates.Length);
            string randomState = animationStates[randomIndex];
            animator.Play(randomState, -1, 1f);
            aniselect = true;
        }
    }

}
