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
            //basketballManager.ThrowInfo();                                                                  // ���� ���� ����, ���� ���� �ӵ�, �� ȸ�� �ӵ� ����
            //ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);    // ���� ȸ�� ����
            //ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse); // ���� �̵� ����
    }

    private void BallRotate() // ���� ������ �� �Ͼ�� ȸ��
    {
        // Pitch x ���� ȸ�� �ӵ� �� �� ��ŭ ���� �޾� ȸ��
        // ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);
    }

    private void BallMove() // ���� ������ �� �Ͼ�� �̵�
    {
        // ������ ���� x ������ �ӵ� �� �� ��ŭ ���� �޾� �̵�
        // ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse);
    }
}
