using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [SerializeField] private GameObject RightHands = null;
    [SerializeField] private GameObject LeftHands = null;
    private Rigidbody ballRigidbody = null;
    private GameObject pickBallHand = null;
    
    private float throwSpeed = 0.0f;
    private Vector3 throwRotate = Vector3.zero;

    private void Start()
    {
        if (!RightHands || !LeftHands) 
        { 
            Debug.Log("BallManager에 손 오브젝트 셋팅해 쨔샤~!!!");
            return;
        }

        if (ballRigidbody == null)
        ballRigidbody = transform.GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        //if (transform.parent.gameObject != null)
        //{
        //    if (transform.parent.gameObject == RightHands || transform.parent.gameObject == LeftHands) // 공을 잡았다면
        //    {
        //        pickBallHand = transform.parent.gameObject;     // 공을 잡은 손 pickBallHand 변수에 저장
        //        Debug.Log("공을 잡은 손 : "+pickBallHand);
        //    }
        //}
        //else                                                    // 공을 잡지 않았다면 and 공을 놓았다면
        //{
        //    if (pickBallHand != null)               // 공을 놓은거라면
        //    {
        //        pickBallHand = null;                            // pickBallHand 변수 초기화
        //        Debug.Log("공을 놓쳤어!!!");
        //        GetThrowInfo();                                 // 공을 던질 속도,방향 구하기
        //        ThrowBall();                                    // 공 던지기!!!
        //    }
        //    else                                    // 공을 애초에 잡지 않은거라면 (-)
        //    { 

        //    }
        //}
    }

    private void GetThrowInfo()                                // 공을 던질 때 필요한 값들 변수에 저장
    {
        throwSpeed = pickBallHand.GetComponent<Rigidbody>().velocity.magnitude;     // 공을 던질 속도
        throwRotate = pickBallHand.transform.rotation.eulerAngles;                  // 공을 던질 방향
        throwRotate.y = 10.0f;                                                      // 공을 위쪽으로 던져야하니까!!!
    }

    private void ThrowBall()                                    // 공을 던지는 기능
    {
        // 공의 Pitch 회전
        ballRigidbody.AddTorque(Vector3.right * throwSpeed, ForceMode.Impulse);
        // 공의 이동
        ballRigidbody.AddForce(throwRotate * throwSpeed, ForceMode.Impulse);
    }

    public void GoalIn()
    {
        // 성공코드에는 전광판 점수 올리기 or 성공 파티클 터뜨리기 or 성공 소리 on 등등을 넣을 수 있음 (-)
    }
}
