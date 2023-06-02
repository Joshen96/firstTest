using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [SerializeField] private Transform goalLineTriggerGO = null;

    [SerializeField, Range(500f, 1000f)] private float rotationSpeed = 800f;
    
    [SerializeField, Range(0f, 10f)] private float distance = 0.2f;
    private float angle = 0f;

    [SerializeField] private SoundManager_sy soundManager = null;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 limitPosition = new Vector3(50f, 100f, 50f);

    public ScoreBoard_sy scoreBoard = null;
    [SerializeField] public int score = 0;
    private Vector3 throwPosition = Vector3.zero;
    private float scoreGuideDist = 12f;

    [SerializeField] private LimitTime_sy limitTime = null;

    private void AWake()
    {
        startPosition = transform.position;
        limitPosition = startPosition + limitPosition;

        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_sy>();
        if (goalLineTriggerGO == null) goalLineTriggerGO = GameObject.Find("GoalLineTriggerGO").transform;

        if (scoreBoard == null) scoreBoard = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard_sy>();
        if (limitTime == null) limitTime = GameObject.Find("LimitTimeCanvas").GetComponent<LimitTime_sy>();
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
                    // 거리에 따라 점수 다르게 얻음
                    if (Mathf.Abs(Vector3.Distance(other.transform.position, throwPosition)) < scoreGuideDist)
                    { score += 3; } // float throwDist = Mathf.Sqrt(Mathf.Pow((throwPosition.x + other.transform.position.x), 2) + Mathf.Pow((throwPosition.z + other.transform.position.z), 2));
                    else { score += 1; }
                    scoreBoard.score = score;

                    scoreBoard.InputScoreToScoreboard();

                    // 회전 반지름 초기화
                    distance = 0.2f;
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
        if (Mathf.Abs(transform.position.x) > limitPosition.x)
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
        else if (Mathf.Abs(transform.position.z) > limitPosition.z)
        {
            transform.position = startPosition;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }

    public void Throw() // 오큘러스 기기로 던질 때 이 함수 넣기(-)
    {
        throwPosition = transform.position;
    }

    public void PickBall()      // 집으면 시행되는 함수(-)
    {
        limitTime.isPickBall = true;
    }
}
