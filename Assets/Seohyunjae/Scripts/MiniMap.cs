using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Transform target; // ĳ������ Transform ����
    public RawImage miniMapImage; // �̴ϸ� �̹��� (RawImage)
    public RectTransform characterDot; // ĳ���� ���� RectTransform

    private Vector2 miniMapSize; // �̴ϸ��� ũ��
    private Vector2 dotStartPosition; // ĳ���� ���� �ʱ� ��ġ

    private void Start()
    {
        miniMapSize = miniMapImage.rectTransform.sizeDelta;
        dotStartPosition = characterDot.anchoredPosition;
    }

    private void LateUpdate()
    {
        // ĳ������ ��ġ�� ���� ĳ���� ���� ��ġ ������Ʈ
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