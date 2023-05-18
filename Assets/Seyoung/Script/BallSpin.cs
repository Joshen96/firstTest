using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{
    // 공의 이동속도가 느린데 트리거에 닿을 경우 뱅글뱅글 돌기

    [SerializeField] private GameObject ballGO = null;  // 볼 오브젝트
    private float ballSpeed = 0.0f;                     // 공의 스피드
    private float limitSpeed = 5.0f;                    // 제한속도
    private bool Rotatable = false;                     // 회전 가능한지
    private GameObject touchTriggerGO = null;           // 공이 닿은 트리거 GO 저장


    private void OnTriggerEnter(Collider other) // 골라인에 닿았을 경우
    {
        if (other.gameObject.name != "GoalTrigger") return;

        // 공이 닿은 트리거 오브젝트 저장
        touchTriggerGO = other.gameObject;

        // 공의 스피드 구하기
        ballSpeed = ballGO.GetComponent<Rigidbody>().velocity.magnitude;

        // 제한속도보다 작으면 회전 가능 true
        if (ballSpeed < limitSpeed) Rotatable = true;
        else Rotatable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GoalTrigger")
        { 
            Rotatable = false;
        }
        touchTriggerGO = null;
    }

    private void SpineOnGoalLine()              // 골라인에서 공 회전
    {
        if (!Rotatable) return;

        // 공과 접촉한 오브젝트 기준 특정 방향으로 AddForce를 사용해
        // 물체에 힘을 가하면 해당방향으로 이동한다.


    }
}
