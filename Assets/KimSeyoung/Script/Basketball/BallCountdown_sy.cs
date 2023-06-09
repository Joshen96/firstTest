using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCountdown_sy : MonoBehaviour
{
    [SerializeField] private GameObject[] countdownNumGO = new GameObject[4];

    private void Awake()
    {
        countdownNumGO[3] = Resources.Load<GameObject>("BallCountdown/count3");
        countdownNumGO[2] = Resources.Load<GameObject>("BallCountdown/count2");
        countdownNumGO[1] = Resources.Load<GameObject>("BallCountdown/count1");
        countdownNumGO[0] = Resources.Load<GameObject>("BallCountdown/go");
    }

    private IEnumerator CountdownInterval() 
    {
        yield return new WaitForSeconds(1f);

    }

}