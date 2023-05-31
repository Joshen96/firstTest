using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform player; // ĳ������ Transform ����
    //public float distance = 10f; // ī�޶�� ĳ���� ������ �Ÿ�
    public float height = 40f; // ī�޶��� ����

    private void LateUpdate()
    {
        // ĳ������ ��ġ�� ���� ī�޶� ��ġ ������Ʈ
        Vector3 targetPosition = player.position;
        Vector3 cameraPosition = targetPosition;
        cameraPosition.y = height; // ī�޶��� ���� ����
        transform.position = cameraPosition;

        // ī�޶��� ȸ���� ����
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}




