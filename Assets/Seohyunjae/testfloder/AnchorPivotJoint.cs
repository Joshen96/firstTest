using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPivotJoint : MonoBehaviour
{
    private Transform tr = null;

    private void Awake()
    {
        tr = transform;
    }

    public void Yaw(float _angleDeg)
    {
        tr.rotation =
            Quaternion.Euler(0f, _angleDeg, 0f);
    }
}
