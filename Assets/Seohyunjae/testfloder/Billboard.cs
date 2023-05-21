using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Video;

// Z-Fighting
public class Billboard : MonoBehaviour
{
    [SerializeField]
    private Transform targetTr = null;

    //private Transform jointTr = null;
    private AnchorPivotJoint apj = null;
    private Screen screen = null;

    // Screen Play Distance
    private readonly float scrPlayDist = 20f;

    private void Awake()
    {
        //GetComponentInChildren
        //GetComponentsInChildren
        //transform.GetChild
        //GameObject.Find
        apj = GetComponentInChildren<AnchorPivotJoint>();
        screen = GetComponentInChildren<Screen>();
    }

    private void Start()
    {
       // VideoClip clip =
         //   Resources.Load<VideoClip>(
           //     "Videos\\TWICE_SETMEFREE");
        //clip =
        //    Resources.Load("Videos\\TWICE_SETMEFREE")
        //    as VideoClip;
        //clip =
        //    (VideoClip)Resources.Load(
        //        "Videos\\TWICE_SETMEFREE");

        //screen.SetVideoClip(clip);
    }

    private void Update()
    {
        float angleRad = CalcAngleToTarget();
        apj.Yaw((90f + 180f) - (angleRad * Mathf.Rad2Deg));

        float dist = CalcDistanceWithTarget();
        if (dist < scrPlayDist) screen.Play();
        else screen.Pause();

        DebugDistance();
    }

    private float CalcAngleToTarget()
    {
        // 방향벡터 구하기
        Vector3 dirToTarget =
            targetTr.position - transform.position;
        dirToTarget.Normalize();

        // Atan(y / x);
        return Mathf.Atan2(dirToTarget.z, dirToTarget.x);
    }

    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            targetTr.position - transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            targetTr.position, transform.position);

        return dist;
    }

    private void DebugDistance()
    {
        Vector3 dirToTarget =
            targetTr.position - transform.position;

        Color color = Color.white;
        if (scrPlayDist < dirToTarget.magnitude)
            color = Color.yellow;
        else
            color = Color.red;

        Debug.DrawLine(
            transform.position,
            targetTr.position,
            color);
    }
}
