using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform player; // 캐릭터의 Transform 참조
    //public float distance = 10f; // 카메라와 캐릭터 사이의 거리
    public float height = 40f; // 카메라의 높이

    private void LateUpdate()
    {
        // 캐릭터의 위치에 따라 카메라 위치 업데이트
        Vector3 targetPosition = player.position;
        Vector3 cameraPosition = targetPosition;
        cameraPosition.y = height; // 카메라의 높이 고정
        transform.position = cameraPosition;

        // 카메라의 회전을 고정
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}




