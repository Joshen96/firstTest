using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager_sy : MonoBehaviour
{
    [SerializeField] private GameObject RightHands = null;
    [SerializeField] private GameObject LeftHands = null;
    private Rigidbody ballRigidbody = null;
    private GameObject pickBallHand = null;
    
    private float throwSpeed = 0.0f;
    private Vector3 throwRotate = Vector3.zero;

    private void Start()
    {
        if (!RightHands || !LeftHands) 
        { 
            Debug.Log("BallManager�� �� ������Ʈ ������ ¹��~!!!");
            return;
        }

        if (ballRigidbody == null)
        ballRigidbody = transform.GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        //if (transform.parent.gameObject != null)
        //{
        //    if (transform.parent.gameObject == RightHands || transform.parent.gameObject == LeftHands) // ���� ��Ҵٸ�
        //    {
        //        pickBallHand = transform.parent.gameObject;     // ���� ���� �� pickBallHand ������ ����
        //        Debug.Log("���� ���� �� : "+pickBallHand);
        //    }
        //}
        //else                                                    // ���� ���� �ʾҴٸ� and ���� ���Ҵٸ�
        //{
        //    if (pickBallHand != null)               // ���� �����Ŷ��
        //    {
        //        pickBallHand = null;                            // pickBallHand ���� �ʱ�ȭ
        //        Debug.Log("���� ���ƾ�!!!");
        //        GetThrowInfo();                                 // ���� ���� �ӵ�,���� ���ϱ�
        //        ThrowBall();                                    // �� ������!!!
        //    }
        //    else                                    // ���� ���ʿ� ���� �����Ŷ�� (-)
        //    { 

        //    }
        //}
    }

    private void GetThrowInfo()                                // ���� ���� �� �ʿ��� ���� ������ ����
    {
        throwSpeed = pickBallHand.GetComponent<Rigidbody>().velocity.magnitude;     // ���� ���� �ӵ�
        throwRotate = pickBallHand.transform.rotation.eulerAngles;                  // ���� ���� ����
        throwRotate.y = 10.0f;                                                      // ���� �������� �������ϴϱ�!!!
    }

    private void ThrowBall()                                    // ���� ������ ���
    {
        // ���� Pitch ȸ��
        ballRigidbody.AddTorque(Vector3.right * throwSpeed, ForceMode.Impulse);
        // ���� �̵�
        ballRigidbody.AddForce(throwRotate * throwSpeed, ForceMode.Impulse);
    }

    public void GoalIn()
    {
        // �����ڵ忡�� ������ ���� �ø��� or ���� ��ƼŬ �Ͷ߸��� or ���� �Ҹ� on ����� ���� �� ���� (-)
    }
}
