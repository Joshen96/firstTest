using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapCameraa : MonoBehaviour
{
    public Transform target; // ĳ������ Transform ����
    public RawImage minimapImage; // �̴ϸ� RawImage ����
    public RectTransform minimapRect; // �̴ϸ��� RectTransform ����

    private RectTransform characterDotRect; // ĳ���� ���� RectTransform ����

    private void Start()
    {
        // ĳ���� ���� RectTransform ���� ��������
        characterDotRect = characterDotRect.GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // ĳ������ ��ġ�� ���� ĳ���� ���� ��ġ ������Ʈ
        Vector3 targetPosition = target.position;
        Vector2 minimapPosition = WorldToMinimapPosition(targetPosition);
        characterDotRect.anchoredPosition = minimapPosition;
    }

    private Vector2 WorldToMinimapPosition(Vector3 worldPosition)
    {
        // ���� ��ǥ�� �̴ϸ� ��ǥ�� ��ȯ
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