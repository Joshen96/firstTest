using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_sy : MonoBehaviour
{

    //[SerializeField] private Basketball_Manager_sy basketballManager = null;

    //private Rigidbody ballRigidbody = null;

    //void Start()
    //{
    //    ballRigidbody = GetComponent<Rigidbody>();
    //    ballRigidbody.mass = 0.5f;
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.name == "�÷��̾� �� �̸�") // �÷��̾��� �հ� �������� ��. ��, ���� �������� ��
    //    {
    //        basketballManager.playerHand = other.gameObject;                                                // ���� ����ִ� �� ����
    //        basketballManager.ThrowInfo();                                                                  // ���� ���� ����, ���� ���� �ӵ�, �� ȸ�� �ӵ� ����
    //        ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);    // ���� ȸ�� ����
    //        ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse); // ���� �̵� ����
    //    }
    //}

    //private void BallRotate() // ���� ������ �� �Ͼ�� ȸ��
    //{
    //    // Pitch x ���� ȸ�� �ӵ� �� �� ��ŭ ���� �޾� ȸ��
    //    ballRigidbody.AddTorque(Vector3.right * basketballManager.ballSpinSpeed, ForceMode.Impulse);
    //}

    //private void BallMove() // ���� ������ �� �Ͼ�� �̵�
    //{
    //    // ������ ���� x ������ �ӵ� �� �� ��ŭ ���� �޾� �̵�
    //    ballRigidbody.AddForce(basketballManager.throwDirection * basketballManager.throwSpeed, ForceMode.Impulse);
    //}
}
