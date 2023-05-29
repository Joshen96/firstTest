using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniMapCamera : MonoBehaviour
{
    public Transform target; // 카메라가 따라다닐 대상의 Transform

    public float smoothSpeed = 0.125f; // 카메라 이동 속도
    public Vector3 offset; // 카메라와 대상 간의 오프셋

    private Vector3 originalPosition; // 카메라의 초기 위치

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = originalPosition.y; // 카메라의 y 위치를 고정
        desiredPosition.z = originalPosition.z; // 카메라의 z 위치를 고정
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f); // 카메라를 위쪽으로 회전
    }
}




