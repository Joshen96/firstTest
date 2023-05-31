using UnityEngine;

public class Rawlmage : MonoBehaviour
{
    public Transform target; // 캐릭터의 Transform 참조
    public float distance = 10f; // 카메라와 캐릭터 사이의 거리
    public GameObject characterDotPrefab; // 캐릭터 점 프리팹

    private GameObject characterDot; // 캐릭터 점 객체

    private void Start()
    {
        // 캐릭터 점 객체 생성
        characterDot = Instantiate(characterDotPrefab, Vector3.zero, Quaternion.identity);
        characterDot.transform.SetParent(transform); // 캐릭터 점을 미니맵 카메라의 자식으로 설정
    }

    private void LateUpdate()
    {
        // 캐릭터의 위치에 따라 카메라 위치 및 캐릭터 점 위치 업데이트
        Vector3 targetPosition = target.position;
        Vector3 cameraPosition = targetPosition - distance * Vector3.forward;
        cameraPosition.y = 40f; // 카메라의 높이 고정
        transform.position = cameraPosition;

        // 카메라의 회전을 고정
        //transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        // 캐릭터 점 위치 업데이트
        characterDot.transform.position = new Vector3(targetPosition.x, 0f, targetPosition.z);
    }
}
