using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ClickBasketball_ball : MonoBehaviour
{

    //[SerializeField] private ClickBasketballManager basketballManager = null;
    //[SerializeField] private GameObject ballGO = null;

    //private Rigidbody ballRigidbody = null;

    void Start()
    {
        //ballRigidbody = GetComponent<Rigidbody>();
        //ballRigidbody.mass = 0.5f;
    }

    private void Update()
    {
            //basketballManager.ThrowInfo();                                                                  // 공을 던질 방향, 공을 던질 속도, 공 회전 속도 설정
            //ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);    // 공의 회전 설정
            //ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse); // 공의 이동 설정
    }

    private void BallRotate() // 공을 던졌을 때 일어나는 회전
    {
        // Pitch x 공의 회전 속도 의 값 만큼 힘을 받아 회전
        // ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);
    }

    private void BallMove() // 공을 던졌을 때 일어나는 이동
    {
        // 던지는 방향 x 던지는 속도 의 값 만큼 힘을 받아 이동
        // ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse);
    }
}
