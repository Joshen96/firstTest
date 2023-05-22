using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_sy : MonoBehaviour
{

    //[SerializeField] private Basketball_Manager_sy basketballManager = null;

    //private Rigidbody ballRigidbody = null;

    //void Start()
    //{
    //    ballRigidbody = GetComponent<Rigidbody>();
    //    ballRigidbody.mass = 0.5f;
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.name == "플레이어 손 이름") // 플레이어의 손과 떨어졌을 때. 즉, 공이 던져졌을 때
    //    {
    //        basketballManager.playerHand = other.gameObject;                                                // 공을 쥐고있는 손 저장
    //        basketballManager.ThrowInfo();                                                                  // 공을 던질 방향, 공을 던질 속도, 공 회전 속도 설정
    //        ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);    // 공의 회전 설정
    //        ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse); // 공의 이동 설정
    //    }
    //}

    //private void BallRotate() // 공을 던졌을 때 일어나는 회전
    //{
    //    // Pitch x 공의 회전 속도 의 값 만큼 힘을 받아 회전
    //    ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);
    //}

    //private void BallMove() // 공을 던졌을 때 일어나는 이동
    //{
    //    // 던지는 방향 x 던지는 속도 의 값 만큼 힘을 받아 이동
    //    ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse);
    //}
}
