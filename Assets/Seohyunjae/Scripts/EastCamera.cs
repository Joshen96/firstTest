using UnityEngine;

public class EastCamera : MonoBehaviour
{
    public Transform target; // 캐릭터의 Transform 컴포넌트

    private Vector3 offset; // 카메라와 캐릭터의 거리 오프셋

    private void Start()
    {
        // 카메라와 캐릭터 사이의 거리 오프셋 계산
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // 카메라의 새로운 위치 계산
        Vector3 newPosition = target.position + offset;

        // 카메라의 위치를 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);

        // 카메라의 회전을 고정하기
        transform.rotation = Quaternion.Euler(45f, -90f, 0f);


    }
}
