using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBasketballManager : MonoBehaviour
{
    //[SerializeField] private GameObject ballGO = null;      // 볼 오브젝트 설정

    ////[SerializeField] private GameObject goalpostGO = null;    // 골대 오브젝트 설정

    //public float throwSpeed = 0.0f;                        //플레이어가 공을 던지는 속도
    //public Vector3 throwDirection = Vector3.zero;          // 플레이어가 공을 던지는 방향
    //public float ballSpinSpeed = 0.0f;                     // 볼을 던졌을 때 볼이 회전할 스피드 

    //private GameObject clickObject = null;                  // 클릭한 오브젝트

    //private void Update()
    //{
    //    // 이 장소가 운동장이 맞는지 확인(-)
    //    // 운동장이 아니면 공을 가지고 나갈 수 없도록 설정 (-)

    //    if (Input.GetMouseButtonDown(0)) // once
    //    { 
    //        FindClickObject(); // 클릭한 오브젝트 찾기
    //    }

    //    if (Input.GetMouseButton(0) && clickObject.name == "Basketball") // ing + 클릭한 오브젝트의 이름이 Basketball이라면
    //    {
    //        MouseFallowingObject(clickObject); // ballGO 가 Mouse를 따라다니도록 설정
    //    }

    //    if (Input.GetMouseButtonUp(0)) // once
    //    {
    //        GetThrowInfo();
    //    }
    //}

    //private void FindClickObject() // 마우스 클릭 시 해당 오브젝트 찾는 함수
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                              // 마우스 포지션에서 광선쏘기
    //    RaycastHit hit;                                                                           // 쏜 광선이 어딘가에 맞았는지를 확인

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.transform.gameObject != null)                               // 광선에 맞은 오브젝트가 null이 아니라면
    //        {
    //            clickObject = hit.transform.gameObject;                         // 클릭한 오브젝트를 ClickObject의 변수값으로 입력
    //        }
    //    }
    //}

    //private void MouseFallowingObject(GameObject _GO) // 오브젝트가 마우스 위치로 이동하도록 만드는 함수
    //{
    //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f); // 마우스 위치
    //    Vector3 ballPosition = Camera.main.ScreenToWorldPoint(mousePosition);                     // 마우스 위치를 ballPositon 변수에 삽입

    //    _GO.transform.position = ballPosition;
    //}

    //public void GetThrowInfo()
    //{
    //    // 이동방향, 이동속도, 회전방향, 회전속도
    //    //throwDirection = playerHand.transform.rotation.eulerAngles;                       // 공을 던질 방향 = 마우스 이동 방향

    //    //throwSpeed = playerHand.gameObject.GetComponent<Rigidbody>().velocity.magnitude;  // 공을 던질 속도 = 공을 쥐고있는 플레이어 손의 속도
    //    //ballSpinSpeed = throwSpeed * 10.0f;                                               // 던지는 속도에 비례하게 회전
    //}
}
