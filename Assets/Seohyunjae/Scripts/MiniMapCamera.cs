using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniMapCamera : MonoBehaviour
{
    public Transform target; // ĳ������ Transform ����
    public float distance = 10f; // ī�޶�� ĳ���� ������ �Ÿ�


    private GameObject characterDot; // ĳ���� �� ��ü



    private void LateUpdate()
    {
        // ĳ������ ��ġ�� ���� ī�޶� ��ġ �� ĳ���� �� ��ġ ������Ʈ
        Vector3 targetPosition = target.position;
        Vector3 cameraPosition = targetPosition - distance * Vector3.forward;
        cameraPosition.y = 40f; // ī�޶��� ���� ����
        transform.position = cameraPosition;

        // ī�޶��� ȸ���� ����
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);


    }
}




