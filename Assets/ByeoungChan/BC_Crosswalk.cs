using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_Crosswalk : MonoBehaviour
{
    public GameObject blockingWallPrefab; // 투명한 벽 프리팹
    public Transform wallSpawnPoint; // 벽 생성 위치

    private bool canCross = false; // 횡단보도를 건널 수 있는지 여부
    private float blockingDuration = 60f; // 길을 막는 시간 (초)
    private float unblockingDuration = 30f; // 길을 열어주는 시간 (초)

    private GameObject blockingWall; // 횡단보도를 막는 벽

    private void Start()
    {
        // 초기 상태로 벽 생성
        CreateBlockingWall();

        // 일정 시간 후에 벽을 해제
        Invoke("UnblockCrossing", blockingDuration);
    }

    private void UnblockCrossing()
    {
        // 횡단보도를 건널 수 있도록 벽을 해제
        canCross = true;

        // 일정 시간 후에 다시 벽을 생성
        Invoke("CreateBlockingWall", unblockingDuration);
    }

    private void CreateBlockingWall()
    {
        // 투명한 벽 생성
        blockingWall = Instantiate(blockingWallPrefab, wallSpawnPoint.position, wallSpawnPoint.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            BC_NPC_Traffic_NavigationController npcController = other.GetComponent<BC_NPC_Traffic_NavigationController>();

            if (npcController != null)
            {
                // NPC가 횡단보도를 건널 수 있는지 확인
                if (!canCross)
                {
                    // 횡단보도를 건널 수 없다면, NPC의 목적지를 현재 위치로 설정하여 멈추도록 함
                    npcController.SetDestination(transform.position);
                }
            }
        }
    }
}
