using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniMapCamera : MonoBehaviour
{
    public Transform target; // ī�޶� ����ٴ� ����� Transform

    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�
    public Vector3 offset; // ī�޶�� ��� ���� ������

    private Vector3 originalPosition; // ī�޶��� �ʱ� ��ġ

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = originalPosition.y; // ī�޶��� y ��ġ�� ����
        desiredPosition.z = originalPosition.z; // ī�޶��� z ��ġ�� ����
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f); // ī�޶� �������� ȸ��
    }
}




