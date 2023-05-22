using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    private Rigidbody ballRigidbody = null;                     // ���� Rigidbody
    [SerializeField] private GameObject pickObject = null;                       // ���� ��ü ������Ʈ
    [SerializeField] private bool isPickBall = false;
    [SerializeField] private float throwSpeed = 0.0f;

    private void Start()
    {
        if (ballRigidbody == null)
        ballRigidbody = transform.GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))             // Ŭ������ ��
        {
            Debug.Log("Ŭ��");
            FindClickObject();                       // Ŭ���� ������Ʈ Ȯ��

            if (pickObject == ballRigidbody.gameObject) pickObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if (Input.GetMouseButton(0))                // ���� Ŭ�����̶��
        {
            if (pickObject == ballRigidbody.gameObject)
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
        throwSpeed = ballRigidbody.velocity.magnitude;                  // ���� ���� �ӵ� = �� �̵� �ӵ�
    }

    private void ThrowBall()                                    // ���� ������ ���
    {
        // ���� Pitch ȸ��
        ballRigidbody.AddTorque(Vector3.right * throwSpeed, ForceMode.Impulse);
        // ���� �̵�
        ballRigidbody.AddForce(transform.position * throwSpeed, ForceMode.Impulse);
    }

    public void GoalIn()
    {
        // �����ڵ忡�� ������ ���� �ø��� or ���� ��ƼŬ �Ͷ߸��� or ���� �Ҹ� on ����� ���� �� ���� (-)
        Debug.Log("����~ ����!!!");
    }







}
