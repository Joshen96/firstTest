using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_sy : MonoBehaviour
{
    private BallManager_sy ballManager = null;
    [SerializeField] private float goalLineRotateSpeed = 5.0f;

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
                    transform.parent.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1,1),0,0) * goalLineRotateSpeed, ForceMode.Impulse);
                    // 골라인에서 회전!!!
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

