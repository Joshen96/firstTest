using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [SerializeField] private GameObject pickObject = null;                       // 잡은 물체 오브젝트
    [SerializeField] private bool isPickBall = false;
    [SerializeField] private float throwSpeed = 0.0f;

    [SerializeField] private Transform targetTr = null;
    [SerializeField, Range(0f, 1000f)] private float speed = 800f;       // 회전 속도
    [SerializeField, Range(0f, 10f)] private float distance = 1f;       // 반지름 Radius
    [SerializeField] private GameObject goalPaticleGO = null;
    private float angle = 0f;

    [SerializeField] private SoundManager soundManager = null;

    private void Start()
    {
        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        goalPaticleGO.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))             // 클릭했을 때
        {
            Debug.Log("클릭");
            FindClickObject();                       // 클릭한 오브젝트 확인

            if (pickObject == this) transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if (Input.GetMouseButton(0))                // 공을 클릭중이라면
        {
            if (pickObject == this)
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
        throwSpeed = GetComponent<Rigidbody>().velocity.magnitude;                  // 공을 던질 속도 = 공 이동 속도
    }

    private void ThrowBall()                                    // 공을 던지는 기능
    {
        // 공의 Pitch 회전
       GetComponent<Rigidbody>().AddTorque(Vector3.right * throwSpeed, ForceMode.Impulse);
        // 공의 이동
        GetComponent<Rigidbody>().AddForce(transform.position * throwSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "GoalLineTrigger": 
                {
                    soundManager.PlayEffectSound("WindSound_");
                }
                break;
            case "GoalInTrigger":
                {
                    soundManager.ESoundAudioSource.volume = 0.5f;
                    soundManager.PlayEffectSound("GoalInSound_");
                }
                break;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "GoalLineTrigger":
                {
                    this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    Debug.Log("touched goalline!!!");

                    if (targetTr == null)
                    { Debug.LogError("회전타겟 오브젝트 설정해!!!"); }

                    if (speed > 500f)
                    {
                        angle -= Time.deltaTime * speed;
                        if (angle < 0f) angle = 360f;

                        Vector3 anglePos = new Vector3();
                        CalcAnglePosWithYaw(angle, ref anglePos);
                        GetComponent<Rigidbody>().AddTorque(Vector3.down * speed, ForceMode.Impulse);

                        Vector3 criterionPos = targetTr.position;

                        speed -= (Time.deltaTime * 100f);
                        this.transform.position = criterionPos + (anglePos * distance);

                        soundManager.ESoundAudioSource.volume -= (Time.deltaTime / 3.5f);
                    }

                    if (speed < 600f)
                    {
                        distance -= Time.deltaTime * 0.1f;
                    }
                }
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {

            case "GoalLineTrigger":
                {
                    GetComponent<Rigidbody>().useGravity = true;
                    speed = 800f;
                }
                break;
            case "GoalInTrigger":
                {
                    GoalIn();
                    distance = 1f;
                }
                break;
        }
    }
    private void CalcAnglePosWithYaw(float _angle, ref Vector3 _pos)
    {
        float angle2Rad = _angle * Mathf.Deg2Rad;

        _pos.x = Mathf.Cos(angle2Rad);
        _pos.y = 0f;
        _pos.z = Mathf.Sin(angle2Rad);
    }



    public void GoalIn()
    {
        // 성공코드에는 전광판 점수 올리기(-)
        goalPaticleGO.SetActive(true);

    }
}
