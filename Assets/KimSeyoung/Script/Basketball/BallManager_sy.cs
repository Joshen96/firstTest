using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [SerializeField] private Transform goalLineTriggerGO = null;        // 골라인 가운데에 있는 트리거 오브젝트
   // [SerializeField] private Transform goalLineTriggerGO1 = null;
    [SerializeField, Range(500f, 1000f)] private float rotationSpeed = 800f;
    
    [SerializeField, Range(0f, 10f)] private float distance = 0.2f;
    private float angle = 0f;

    [SerializeField] private SoundManager_sy soundManager = null;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 limitPosition = new Vector3(50f, 100f, 50f);
    private float limitDistance = 50f;

    private void Start()
    {
        startPosition = transform.position;
        limitPosition = startPosition + limitPosition;

        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_sy>();
        if (goalLineTriggerGO == null) goalLineTriggerGO = GameObject.Find("GoalLineTriggerGO").transform;

    }

    private void Update()
    {
        PositionReset();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "GoalLineTrigger": 
                {
                    soundManager.ESoundAudioSource.volume = 0.7f;
                    soundManager.PlayEffectSound("WindSound_");
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

                    if (rotationSpeed > 600f)
                    {
                        angle -= Time.deltaTime * rotationSpeed;
                        if (angle < 0f) angle = 360f;

                        Vector3 anglePos = new Vector3();
                        CalcAnglePosWithYaw(angle, ref anglePos);
                        GetComponent<Rigidbody>().AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);

                        Vector3 criterionPos = goalLineTriggerGO.position;

                        rotationSpeed -= (Time.deltaTime * 100f);
                        this.transform.position = criterionPos + (anglePos * distance);

                        soundManager.ESoundAudioSource.volume -= (Time.deltaTime / 3.5f);
                    }

                    if (rotationSpeed < 700f)
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
                    rotationSpeed = 800f;
                }
                break;
            case "GoalInTrigger":
                {
                    distance = 0.2f;
                    // 전광판 오브젝트 추가(-), 점수 연동(-)
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

    private void PositionReset() //속도
    {
        if (transform.position.x > limitPosition.x)
        {
            transform.position = startPosition;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().isKinematic = false;

        }
        else if (transform.position.y > limitPosition.y)
        {
            transform.position = startPosition;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (transform.position.z > limitPosition.z)
        {
            transform.position = startPosition;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }


}
