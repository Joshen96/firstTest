using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapCameraa : MonoBehaviour
{
    public Transform target; // 캐릭터의 Transform 참조
    public RawImage minimapImage; // 미니맵 RawImage 참조
    public RectTransform minimapRect; // 미니맵의 RectTransform 참조

    private RectTransform characterDotRect; // 캐릭터 점의 RectTransform 참조

    private void Start()
    {
        // 캐릭터 점의 RectTransform 참조 가져오기
        characterDotRect = characterDotRect.GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // 캐릭터의 위치에 따라 캐릭터 점의 위치 업데이트
        Vector3 targetPosition = target.position;
        Vector2 minimapPosition = WorldToMinimapPosition(targetPosition);
        characterDotRect.anchoredPosition = minimapPosition;
    }

    private Vector2 WorldToMinimapPosition(Vector3 worldPosition)
    {
        // 월드 좌표를 미니맵 좌표로 변환
        float minimapWidth = minimapRect.rect.width;
        float minimapHeight = minimapRect.rect.height;
        float worldX = worldPosition.x;
        float worldZ = worldPosition.z;
        float minX = minimapRect.anchoredPosition.x - minimapWidth / 2f;
        float maxX = minimapRect.anchoredPosition.x + minimapWidth / 2f;
        float minY = minimapRect.anchoredPosition.y - minimapHeight / 2f;
        float maxY = minimapRect.anchoredPosition.y + minimapHeight / 2f;

        float normalizedX = Mathf.InverseLerp(minX, maxX, worldX);
        float normalizedY = Mathf.InverseLerp(minY, maxY, worldZ);

        float dotX = Mathf.Lerp(minX, maxX, normalizedX);
        float dotY = Mathf.Lerp(minY, maxY, normalizedY);

        return new Vector2(dotX, dotY);
    }
}