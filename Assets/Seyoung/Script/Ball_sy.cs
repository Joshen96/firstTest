using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_sy : MonoBehaviour
{
    private BallManager_sy ballManager = null;

    private void Start()
    {
        ballManager = transform.parent.GetComponent<BallManager_sy>();
    }

    public void OnTriggerEnter(Collider other) 
    {
        switch (other.gameObject.name)
        {
            case "GoalLineTrigger":
                {
                    // 공이 회전하다가 들어가기 (-)
                }
                break;

            case "GoalInTrigger":
                {
                    ballManager.GoalIn();               // 골인했다고 알려주기
                }
                break;
        }
    }
}
