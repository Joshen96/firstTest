using UnityEngine;

public class Rawlmage : MonoBehaviour
{
    public Transform target; // ĳ������ Transform ����
    public float distance = 10f; // ī�޶�� ĳ���� ������ �Ÿ�
    public GameObject characterDotPrefab; // ĳ���� �� ������

    private GameObject characterDot; // ĳ���� �� ��ü

    private void Start()
    {
        // ĳ���� �� ��ü ����
        characterDot = Instantiate(characterDotPrefab, Vector3.zero, Quaternion.identity);
        characterDot.transform.SetParent(transform); // ĳ���� ���� �̴ϸ� ī�޶��� �ڽ����� ����
    }

    private void LateUpdate()
    {
        // ĳ������ ��ġ�� ���� ī�޶� ��ġ �� ĳ���� �� ��ġ ������Ʈ
        Vector3 targetPosition = target.position;
        Vector3 cameraPosition = targetPosition - distance * Vector3.forward;
        cameraPosition.y = 40f; // ī�޶��� ���� ����
        transform.position = cameraPosition;

        // ī�޶��� ȸ���� ����
        //transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        // ĳ���� �� ��ġ ������Ʈ
        characterDot.transform.position = new Vector3(targetPosition.x, 0f, targetPosition.z);
    }
}
