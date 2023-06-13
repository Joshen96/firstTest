using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [Header("- for BallSpin -")]
    [SerializeField] private Transform goalLineTriggerGO = null;
    [SerializeField, Range(500f, 1000f)] private float rotationSpeed = 800f;
    [SerializeField, Range(0f, 10f)] private float distance = 0.2f;
    [SerializeField] private SoundManager_sy soundManager = null;
    private float spinAngle = 0f;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 limitPosition = new Vector3(25f, 50f, 25f);

    [Header("- for Backboard -")]
    public bool isPickBall = false;
    private Vector3 throwPosition = Vector3.zero;
    public float BallToBackboardDis = 0.0f;

    private void Awake()
    {
        startPosition = transform.position;
        limitPosition = startPosition + limitPosition;

        throwPosition = startPosition;

        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_sy>();

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
                        spinAngle -= Time.deltaTime * rotationSpeed;
                        if (spinAngle < 0f) spinAngle = 360f;

                        Vector3 anglePos = new Vector3();
                        CalcAnglePosWithYaw(spinAngle, ref anglePos);
                        GetComponent<Rigidbody>().AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);

                        //Vector3 criterionPos = goalLineTriggerGO.position;
                        Vector3 criterionPos = other.transform.position;

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
                    // 골대와 공을 던진 위치의 차
                    BallToBackboardDis = Mathf.Abs(Vector3.Distance(other.transform.position, throwPosition));

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

    private void PositionReset()
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

    public void Throw()
    {
        throwPosition = transform.position;
        isPickBall = false;
    }

    public void PickBall()
    {
        isPickBall = true;
        if (!Mission_imfo.isPlayingBasketball) Mission_imfo.isPlayingBasketball = true;
    }
}
