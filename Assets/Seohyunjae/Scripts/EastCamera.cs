using UnityEngine;

public class EastCamera : MonoBehaviour
{
    public Transform target; // ĳ������ Transform ������Ʈ

    private Vector3 offset; // ī�޶�� ĳ������ �Ÿ� ������

    private void Start()
    {
        // ī�޶�� ĳ���� ������ �Ÿ� ������ ���
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // ī�޶��� ���ο� ��ġ ���
        Vector3 newPosition = target.position + offset;

        // ī�޶��� ��ġ�� �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);

        // ī�޶��� ȸ���� �����ϱ�
        transform.rotation = Quaternion.Euler(45f, -90f, 0f);


    }
}
