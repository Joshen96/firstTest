using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [SerializeField] private GameObject pickObject = null;                       // ���� ��ü ������Ʈ
    [SerializeField] private bool isPickBall = false;
    [SerializeField] private float throwSpeed = 0.0f;

    [SerializeField] private Transform targetTr = null;
    [SerializeField, Range(0f, 1000f)] private float speed = 800f;       // ȸ�� �ӵ�
    [SerializeField, Range(0f, 10f)] private float distance = 1f;       // ������ Radius
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
        if (Input.GetMouseButtonDown(0))             // Ŭ������ ��
        {
            Debug.Log("Ŭ��");
            FindClickObject();                       // Ŭ���� ������Ʈ Ȯ��

            if (pickObject == this) transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if (Input.GetMouseButton(0))                // ���� Ŭ�����̶��
        {
            if (pickObject == this)
            {
                isPickBall = true;
            }
        }

        if (isPickBall && Input.GetMouseButtonUp(0))              // ���� ������ ��
        {
            Debug.Log("���� ������!!!");
            pickObject = null;
            isPickBall = false;
            GetThrowInfo();                                 // ���� ���� �ӵ�,���� ���ϱ�
            ThrowBall();                                    // �� ������!!!
        }
    }

    private void FindClickObject() // ���콺 Ŭ�� �� �ش� ������Ʈ ã�� �Լ�
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("����" + ray);// ���콺 �����ǿ��� �������
        RaycastHit hit;                                                         // �� ������ ��򰡿� �¾Ҵ����� Ȯ��

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject != null)                               // ������ ���� ������Ʈ�� null�� �ƴ϶��
            {
                pickObject = hit.transform.gameObject;                          // Ŭ���� ������Ʈ�� ClickObject�� ���������� �Է�
            }
        }
    }


    private void GetThrowInfo()                                // ���� ���� �� �ʿ��� ���� ������ ����
    {
        throwSpeed = GetComponent<Rigidbody>().velocity.magnitude;                  // ���� ���� �ӵ� = �� �̵� �ӵ�
    }

    private void ThrowBall()                                    // ���� ������ ���
    {
        // ���� Pitch ȸ��
       GetComponent<Rigidbody>().AddTorque(Vector3.right * throwSpeed, ForceMode.Impulse);
        // ���� �̵�
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
                    { Debug.LogError("ȸ��Ÿ�� ������Ʈ ������!!!"); }

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
        // �����ڵ忡�� ������ ���� �ø���(-)
        goalPaticleGO.SetActive(true);

    }
}
