using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [SerializeField] private GameObject pickObject = null;                       // ���� ��ü ������Ʈ
    [SerializeField] private bool isPickBall = false;
    [SerializeField] private float throwSpeed = 0.0f;

    [SerializeField] private float goalLineRotateSpeed = 5.0f; //(????)


    /// <summary>
    /// ///////////////////////////////////////////
    /// </summary>
    private enum ERotDir { CW, CCW }                                    // ȸ������ ����
    private enum ERotType { Pitch, Yaw, Roll }                          // ��ȸ�� ����

    [Header("- Values -")]
    [SerializeField, Range(0f, 300f)] private float speed = 100f;       // ȸ�� �ӵ�
    [SerializeField, Range(0f, 10f)] private float distance = 1f;       // ������ Radius

    [Header("- Type -")]
    [SerializeField] private ERotDir rotDir = ERotDir.CCW;              // �⺻ ���� ���� 
    [SerializeField] private ERotType rotType = ERotType.Yaw;           // �⺻ ȸ���� ����
    /// <summary>
    /// ///////////////////////////////////////////
    /// </summary>





    private void Awake()
    {

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


    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "GoalTrigger":
                {
                    Debug.Log("����� ��Ҿ�!!!");
                    // GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), 0, 0) * goalLineRotateSpeed, ForceMode.Impulse);
                    // ����ο��� ȸ��!!! (-) AroundMoveBall ��ũ��Ʈ �����ؼ� �ٽ� �����!
                    // ƨ�ܳ����ݾ�!!!! (-)
                }
                break;

            case "GoalInTrigger":
                {
                    Debug.Log("���� �߾�!!!");
                    GoalIn();               // �����ߴٰ� �˷��ֱ�
                }
                break;
        }
    }

    public void GoalIn()
    {
        // �����ڵ忡�� ������ ���� �ø��� or ���� ��ƼŬ �Ͷ߸��� or ���� �Ҹ� on ����� ���� �� ���� (-)
        Debug.Log("����~ ����!!!");
    }
}
