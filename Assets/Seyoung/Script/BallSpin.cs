using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{
    // ���� �̵��ӵ��� ������ Ʈ���ſ� ���� ��� ��۹�� ����

    [SerializeField] private GameObject ballGO = null;  // �� ������Ʈ
    private float ballSpeed = 0.0f;                     // ���� ���ǵ�
    private float limitSpeed = 5.0f;                    // ���Ѽӵ�
    private bool Rotatable = false;                     // ȸ�� ��������
    private GameObject touchTriggerGO = null;           // ���� ���� Ʈ���� GO ����


    private void OnTriggerEnter(Collider other) // ����ο� ����� ���
    {
        if (other.gameObject.name != "GoalTrigger") return;

        // ���� ���� Ʈ���� ������Ʈ ����
        touchTriggerGO = other.gameObject;

        // ���� ���ǵ� ���ϱ�
        ballSpeed = ballGO.GetComponent<Rigidbody>().velocity.magnitude;

        // ���Ѽӵ����� ������ ȸ�� ���� true
        if (ballSpeed < limitSpeed) Rotatable = true;
        else Rotatable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GoalTrigger")
        { 
            Rotatable = false;
        }
        touchTriggerGO = null;
    }

    private void SpineOnGoalLine()              // ����ο��� �� ȸ��
    {
        if (!Rotatable) return;

        // ���� ������ ������Ʈ ���� Ư�� �������� AddForce�� �����
        // ��ü�� ���� ���ϸ� �ش�������� �̵��Ѵ�.


    }
}
