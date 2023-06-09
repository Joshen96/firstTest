using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Birdmove : MonoBehaviour
{
    public Transform bird;
    public Transform[] paths;
    public Transform Player;
    public Animator animator;

    public float speed = 1.5f;
    public float scrPlayDist = 4.0f;
    public int i = 0;

    public float rotationSpeed = 70f; // 회전 속도
    private bool isBounce = false;
    public string[] animationStates;
    private bool aniselect = false;
    // Start is called before the first frame update
    private void Start()
    {
        bird.transform.position = paths[0].transform.position;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float dist = CalcDistanceWithTarget();

        if (dist < scrPlayDist)
        {
            //animator.SetBool("Bounce", !isBounce);
            transform.LookAt(Player.position);
            transform.RotateAround(Player.position, Vector3.up, rotationSpeed * Time.deltaTime);

            //catangleturn.transform.rotation = Quaternion.Euler(Vector3.right * 180f);
            //Debug.Log(Quaternion.Euler(Vector3.right * dist));
            //transform.RotateAround(Player.position, Vector3.up, rotationSpeed * Time.deltaTime);
            if (!aniselect)
            {
                PlayRandomAnimation();
                
            }

        }
        else
        {
            aniselect = false;
            animator.Play("Fly");
            animator.SetBool("Bounce", isBounce);
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
    }
    public void lookingPlayer(Transform _nextpath)
    {
        Vector3 dir = _nextpath.transform.position - bird.transform.position;
        bird.gameObject.transform.rotation = Quaternion.Lerp(bird.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);

    }
    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            Player.position - bird.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            Player.position, bird.transform.position);

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