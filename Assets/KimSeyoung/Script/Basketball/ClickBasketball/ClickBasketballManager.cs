using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBasketballManager : MonoBehaviour
{
    //[SerializeField] private GameObject ballGO = null;      // �� ������Ʈ ����

    ////[SerializeField] private GameObject goalpostGO = null;    // ��� ������Ʈ ����

    //public float throwSpeed = 0.0f;                        //�÷��̾ ���� ������ �ӵ�
    //public Vector3 throwDirection = Vector3.zero;          // �÷��̾ ���� ������ ����
    //public float ballSpinSpeed = 0.0f;                     // ���� ������ �� ���� ȸ���� ���ǵ� 

    //private GameObject clickObject = null;                  // Ŭ���� ������Ʈ

    //private void Update()
    //{
    //    // �� ��Ұ� ����� �´��� Ȯ��(-)
    //    // ����� �ƴϸ� ���� ������ ���� �� ������ ���� (-)

    //    if (Input.GetMouseButtonDown(0)) // once
    //    { 
    //        FindClickObject(); // Ŭ���� ������Ʈ ã��
    //    }

    //    if (Input.GetMouseButton(0) && clickObject.name == "Basketball") // ing + Ŭ���� ������Ʈ�� �̸��� Basketball�̶��
    //    {
    //        MouseFallowingObject(clickObject); // ballGO �� Mouse�� ����ٴϵ��� ����
    //    }

    //    if (Input.GetMouseButtonUp(0)) // once
    //    {
    //        GetThrowInfo();
    //    }
    //}

    //private void FindClickObject() // ���콺 Ŭ�� �� �ش� ������Ʈ ã�� �Լ�
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                              // ���콺 �����ǿ��� �������
    //    RaycastHit hit;                                                                           // �� ������ ��򰡿� �¾Ҵ����� Ȯ��

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.transform.gameObject != null)                               // ������ ���� ������Ʈ�� null�� �ƴ϶��
    //        {
    //            clickObject = hit.transform.gameObject;                         // Ŭ���� ������Ʈ�� ClickObject�� ���������� �Է�
    //        }
    //    }
    //}

    //private void MouseFallowingObject(GameObject _GO) // ������Ʈ�� ���콺 ��ġ�� �̵��ϵ��� ����� �Լ�
    //{
    //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f); // ���콺 ��ġ
    //    Vector3 ballPosition = Camera.main.ScreenToWorldPoint(mousePosition);                     // ���콺 ��ġ�� ballPositon ������ ����

    //    _GO.transform.position = ballPosition;
    //}

    //public void GetThrowInfo()
    //{
    //    // �̵�����, �̵��ӵ�, ȸ������, ȸ���ӵ�
    //    //throwDirection = playerHand.transform.rotation.eulerAngles;                       // ���� ���� ���� = ���콺 �̵� ����

    //    //throwSpeed = playerHand.gameObject.GetComponent<Rigidbody>().velocity.magnitude;  // ���� ���� �ӵ� = ���� ����ִ� �÷��̾� ���� �ӵ�
    //    //ballSpinSpeed = throwSpeed * 10.0f;                                               // ������ �ӵ��� ����ϰ� ȸ��
    //}
}
