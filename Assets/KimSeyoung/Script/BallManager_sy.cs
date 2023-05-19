using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    private Rigidbody ballRigidbody = null;                     // 공의 Rigidbody
    [SerializeField] private GameObject pickObject = null;                       // 잡은 물체 오브젝트
    [SerializeField] private bool isPickBall = false;
    [SerializeField] private float throwSpeed = 0.0f;

    private void Start()
    {
        if (ballRigidbody == null)
        ballRigidbody = transform.GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))             // 클릭했을 때
        {
            Debug.Log("클릭");
            FindClickObject();                       // 클릭한 오브젝트 확인

            if (pickObject == ballRigidbody.gameObject) pickObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if (Input.GetMouseButton(0))                // 공을 클릭중이라면
        {
            if (pickObject == ballRigidbody.gameObject)
            {
                isPickBall = true;
            }
        }

        if (isPickBall && Input.GetMouseButtonUp(0))              // 공을 놓았을 때
        {
            Debug.Log("공을 던졌어!!!");
            pickObject = null;
            isPickBall = false;
            GetThrowInfo();                                 // 공을 던질 속도,방향 구하기
            ThrowBall();                                    // 공 던지기!!!
        }
    }

    private void FindClickObject() // 마우스 클릭 시 해당 오브젝트 찾는 함수
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("레이" + ray);// 마우스 포지션에서 광선쏘기
        RaycastHit hit;                                                         // 쏜 광선이 어딘가에 맞았는지를 확인

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject != null)                               // 광선에 맞은 오브젝트가 null이 아니라면
            {
                pickObject = hit.transform.gameObject;                          // 클릭한 오브젝트를 ClickObject의 변수값으로 입력
            }
        }
    }


    private void GetThrowInfo()                                // 공을 던질 때 필요한 값들 변수에 저장
    {
        throwSpeed = ballRigidbody.velocity.magnitude;                  // 공을 던질 속도 = 공 이동 속도
    }

    private void ThrowBall()                                    // 공을 던지는 기능
    {
        // 공의 Pitch 회전
        ballRigidbody.AddTorque(Vector3.right * throwSpeed, ForceMode.Impulse);
        // 공의 이동
        ballRigidbody.AddForce(transform.position * throwSpeed, ForceMode.Impulse);
    }

    public void GoalIn()
    {
        // 성공코드에는 전광판 점수 올리기 or 성공 파티클 터뜨리기 or 성공 소리 on 등등을 넣을 수 있음 (-)
        Debug.Log("오예~ 골인!!!");
    }







}
