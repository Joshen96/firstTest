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
                    // ���� ȸ���ϴٰ� ���� (-)
                }
                break;

            case "GoalInTrigger":
                {
                    ballManager.GoalIn();               // �����ߴٰ� �˷��ֱ�
                }
                break;
        }
    }
}
