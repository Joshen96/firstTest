using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Transform target; // 캐릭터의 Transform 참조
    public RawImage miniMapImage; // 미니맵 이미지 (RawImage)
    public RectTransform characterDot; // 캐릭터 점의 RectTransform

    private Vector2 miniMapSize; // 미니맵의 크기
    private Vector2 dotStartPosition; // 캐릭터 점의 초기 위치

    private void Start()
    {
        miniMapSize = miniMapImage.rectTransform.sizeDelta;
        dotStartPosition = characterDot.anchoredPosition;
    }

    private void LateUpdate()
    {
        // 캐릭터의 위치에 따라 캐릭터 점의 위치 업데이트
        Vector2 normalizedPosition = new Vector2(
            (target.position.x - miniMapImage.rectTransform.position.x) / miniMapSize.x,
            (target.position.z - miniMapImage.rectTransform.position.y) / miniMapSize.y
        );

        Vector2 dotPosition = new Vector2(
            normalizedPosition.x * miniMapSize.x,
            normalizedPosition.y * miniMapSize.y
        );

        characterDot.anchoredPosition = dotStartPosition + dotPosition;
    }
}