using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_Crosswalk : MonoBehaviour
{
    public GameObject blockingWallPrefab; // ������ �� ������
    public Transform wallSpawnPoint; // �� ���� ��ġ

    private bool canCross = false; // Ⱦ�ܺ����� �ǳ� �� �ִ��� ����
    private float blockingDuration = 60f; // ���� ���� �ð� (��)
    private float unblockingDuration = 30f; // ���� �����ִ� �ð� (��)

    private GameObject blockingWall; // Ⱦ�ܺ����� ���� ��

    private void Start()
    {
        // �ʱ� ���·� �� ����
        CreateBlockingWall();

        // ���� �ð� �Ŀ� ���� ����
        Invoke("UnblockCrossing", blockingDuration);
    }

    private void UnblockCrossing()
    {
        // Ⱦ�ܺ����� �ǳ� �� �ֵ��� ���� ����
        canCross = true;

        // ���� �ð� �Ŀ� �ٽ� ���� ����
        Invoke("CreateBlockingWall", unblockingDuration);
    }

    private void CreateBlockingWall()
    {
        // ������ �� ����
        blockingWall = Instantiate(blockingWallPrefab, wallSpawnPoint.position, wallSpawnPoint.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            BC_NPC_Traffic_NavigationController npcController = other.GetComponent<BC_NPC_Traffic_NavigationController>();

            if (npcController != null)
            {
                // NPC�� Ⱦ�ܺ����� �ǳ� �� �ִ��� Ȯ��
                if (!canCross)
                {
                    // Ⱦ�ܺ����� �ǳ� �� ���ٸ�, NPC�� �������� ���� ��ġ�� �����Ͽ� ���ߵ��� ��
                    npcController.SetDestination(transform.position);
                }
            }
        }
    }
}
